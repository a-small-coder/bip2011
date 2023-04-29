using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace PipeServer
{


    class Signature
    {
        public static string signaturePath = "C:\\Users\\hulkt\\OneDrive\\Документы\\antivirus\\PipeServer\\signature.txt";
        public static string QuarantinePath = "C:\\Quarantine";
        public static string RecoverPath = "C:\\Recover";

        public static int numScanFiles;
        public static List<string> virusFiles = new List<string> { };
        public static int VirusCount;

        // считывает данные из файла с сигнатурами (signature.txt) и загружает каждую сигнатуру в дерево
        public static RBTree LoadSignatures(string fileName, RBTree tree)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] parts = streamReader.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        long offset = Convert.ToInt64(parts[0], 16);
                        byte[] signature = StringToByteArray(parts[1]);
                        string name = parts[2];
                        tree.Add(signature, offset, name);
                    }
                    else
                    {
                        Console.WriteLine("Using signature bases " + parts[0]);
                    }
                }
            }
            return tree;
        }
        // преобразовывает строки из файла с сигнатурами в масисв байтов

        public static void clearScanResults()
        {
            numScanFiles = 0;
            virusFiles = new List<string> { };
            VirusCount = 0;
    } 
        static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");
            byte[] byteArray = new byte[hex.Length / 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hex.Substring(2 * i, 2), 16);
            }
            return byteArray;
        }
        // преобразовывает файл в массив байтов
        public static byte[] file_to_bin(string filename)
        {

            byte[] bin_data = File.ReadAllBytes(filename);

            return bin_data;
        }
        // сравнивает байты файла с сигнатурами в дереве, если находит, выводит файл и название сигнатуры, которую нашел
        public static void find_sign_in_file(string file, RBTree tree)
        {

            numScanFiles += 1;
            byte[] check_data = Signature.file_to_bin(file);

            Node node = tree.FindNode(check_data);
            if (node != null)
            {

                Console.WriteLine(file + "\n" + node.Name);
                virusFiles.Add(file);
                // перемещаем файо в карантин
                MoveToQuarantine(file);
            }


        }

        // поиск внутри архива

        public static void SearchArchive(string archivePath, RBTree signature)
        {
            bool is_virus_detected_in_archive = false;
            using (var archive = ZipFile.OpenRead(archivePath))
            {
                //проходимся по файлам архива
                foreach (var entry in archive.Entries)
                {
                    if (!entry.FullName.EndsWith("/"))
                    {

                        //все файлы архива можно найти в temp, находим путь к файлу
                        var filePath = Path.Combine(Path.GetTempPath(), entry.FullName);
                        //извлекаем элемент во временный файл entry
                        entry.ExtractToFile(filePath, true);
                        if (entry.FullName.Contains(".zip"))
                        {
                            Signature.SearchArchive(filePath, signature);
                        }
                        else
                        {
                            byte[] check_data = Signature.file_to_bin(filePath);
                            Node node = signature.FindNode(check_data);
                            if (node != null)
                            {
                                is_virus_detected_in_archive = true;
                                Console.WriteLine(entry + "\n" + node.Name);
                                virusFiles.Add(entry.FullName);
                            }
                        }
                        //удаляем временный файл
                        File.Delete(filePath);
                    }
                }

            }
            if (is_virus_detected_in_archive)
            {
                MoveToQuarantine(archivePath);
            }
        }




        // рекурсивно проходит по всем папкам и файлам, файлы отправляет в метод find_sign_in_file
        public static void FindFiles(string directory, string searchPattern, RBTree tree, Func<string, int> SendMessage)
        {
            int count_scaning_file = 0;
            try
            {
                if (directory.Split('.').Length == 1)
                {
                    SendMessage("scan directory  " + directory + Environment.NewLine);
                    foreach (string file in Directory.GetFiles(directory, searchPattern))
                    {
                        SendMessage(file + Environment.NewLine);
                        FileInfo size = new FileInfo(file);
                        //если попавшийся файл - архив
                        if (size.Name.Contains(".zip"))
                        {
                            count_scaning_file += 1;
                            Signature.SearchArchive(file, tree);

                        }
                        if (size.Length < 200000000)
                        {

                            Signature.find_sign_in_file(file, tree);

                        }

                    }

                    foreach (string subDir in Directory.GetDirectories(directory))
                    {
                        SendMessage(Environment.NewLine);
                        FindFiles(subDir, searchPattern, tree, SendMessage);

                    }
                }
                else
                {
                    SendMessage("scan current file" + Environment.NewLine + directory + Environment.NewLine);
                    FileInfo size = new FileInfo(directory);
                    if (size.Name.Contains(".zip"))
                    {
                        count_scaning_file+=1;
                        Signature.SearchArchive(directory, tree);

                    }
                    if (size.Length < 200000000)
                    {
                        Signature.find_sign_in_file(directory, tree);

                    }
                }
                


            }
            catch 
            {
                // если нет доступа к директории, то пропустить ее
            }
            numScanFiles += count_scaning_file;
            VirusCount = virusFiles.Count;
            System.Console.WriteLine("Количество просканированных файлов: " + count_scaning_file);
        }


        //карантин
        public static void MoveToQuarantine(string filePath)
        {
            try
            {
                if (!Directory.Exists(QuarantinePath))
                {
                    Directory.CreateDirectory(QuarantinePath);
                    Console.WriteLine("Папка успешно создана.");
                }
                string quarantinePath = Path.Combine(QuarantinePath, Path.GetFileName(filePath));
                if (File.Exists(quarantinePath))
                {
                    // Если файл с таким именем уже есть в карантине, переименовываем его
                    quarantinePath = Path.Combine(QuarantinePath, Guid.NewGuid().ToString() + Path.GetExtension(filePath));
                }
                byte[] crypt_file = File.ReadAllBytes(filePath);
                crypt_file = Crypt(crypt_file);
                //string crypt_file_name = GetNewFileName(filePath);
                File.WriteAllBytes(filePath, crypt_file);
                File.Move(filePath, quarantinePath);
            }

            catch
            {

            }
            

        }

        // шифрование через XOR (дешифрование тоже через этот метод)
        private static byte[] Crypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= 1;
            return bytes;
        }
        //меняет имя зашифрованного файла на /файл/.crypt
        public static void Recover(string recoverFile)
        {
            /* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                      ПРИ ПРОВЕРКЕ ПОМЕНЯЙТЕ ПУТИ
             !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

            //если папки с восстановленными файлами нет, создаем ее
            string quarantinePath = Path.Combine(QuarantinePath, Path.GetFileName(recoverFile));
            string recoverPath = RecoverPath;
            //string recover = @"C:\Users\Lenovo\Desktop\Quarantine\" 
            try
            {
                if (!Directory.Exists(recoverPath))
                {
                    Directory.CreateDirectory(recoverPath);
                    Console.WriteLine("Папка успешно создана.");
                }
                else
                {
                    Console.WriteLine("Папка уже существует");
                }

                string recoverFilePath = Path.Combine(RecoverPath, Path.GetFileName(recoverFile));
                if (File.Exists(recoverPath))
                {
                    // Если файл с таким именем уже есть в папке, переименовываем его
                    recoverFilePath = Path.Combine(RecoverPath, Guid.NewGuid().ToString() + Path.GetExtension(recoverFile));
                }

                byte[] decrypt_file = File.ReadAllBytes(quarantinePath);
                decrypt_file = Crypt(decrypt_file);

                File.WriteAllBytes(quarantinePath, decrypt_file);
                File.Move(quarantinePath, recoverFilePath);
            }

            catch
            {

            }
            

        }


    }
}

