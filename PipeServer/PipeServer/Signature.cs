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
        public static string signaturePath = "C:\\Users\\hulkt\\OneDrive\\Документы\\antivirus\\antivirus-wat\\antivirus-main\\PipeServer\\signature.txt";

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

            byte[] check_data = Signature.file_to_bin(file);

            Node node = tree.FindNode(check_data);
            if (node != null)
            {

                Console.WriteLine(file + "\n" + node.Name);
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
        public static void FindFiles(string directory, string searchPattern, RBTree tree)
        {
            int count_scaning_file = 0;
            try
            {

                foreach (string file in Directory.GetFiles(directory, searchPattern))
                {
                    FileInfo size = new FileInfo(file);
                    //если попавшийся файл - архив
                    if (size.Name.Contains(".zip"))
                    {
                        count_scaning_file++;
                        Signature.SearchArchive(file, tree);

                    }
                    if (size.Length < 200000000)
                    {
                        count_scaning_file++;

                        Signature.find_sign_in_file(file, tree);

                    }



                }

                foreach (string subDir in Directory.GetDirectories(directory))
                {
                    count_scaning_file++;

                    FindFiles(subDir, searchPattern, tree);

                }


            }
            catch (UnauthorizedAccessException)
            {
                // если нет доступа к директории, то пропустить ее
            }
            System.Console.WriteLine("Количество просканированных файлов: " + count_scaning_file);
        }


        //карантин
        private static void MoveToQuarantine(string filePath)
        {
            string quarantinePath = @"C:\Users\Lenovo\Desktop\Quarantine\" + Path.GetFileName(filePath);
            if (File.Exists(quarantinePath))
            {
                // Если файл с таким именем уже есть в карантине, переименовываем его
                quarantinePath = @"C:\Users\Lenovo\Desktop\Quarantine\" + Guid.NewGuid().ToString() + Path.GetExtension(filePath);
            }
            byte[] crypt_file = File.ReadAllBytes(filePath);
            crypt_file = Crypt(crypt_file);
            //string crypt_file_name = GetNewFileName(filePath);
            File.WriteAllBytes(filePath, crypt_file);
            File.Move(filePath, quarantinePath);

        }

        // шифрование через XOR (дешифрование тоже через этот метод)
        private static byte[] Crypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= 1;
            return bytes;
        }
        //меняет имя зашифрованного файла на /файл/.crypt
        private static string GetNewFileName(string FileName)
        {
            return FileName.EndsWith(".crypt") ? FileName.Remove(FileName.LastIndexOf(".crypt")) : FileName + ".crypt";
        }

    }
}

