using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace PipeServer
{
    public class Watcher

    {
        public static FileSystemWatcher watcher;
        public static string watcherPath = "C:\\Users\\hulkt\\OneDrive\\Документы\\сети\\лабы";
        public static void Start()
        {
            Console.WriteLine("запускаем вотчер");
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = Watcher.watcherPath;
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {

            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
            //   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            //watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            //Console.WriteLine("Press \'q\' to quit the sample.");
            //while (Console.Read() != 'q') ;
        }

        public static void Stop()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Changed -= new FileSystemEventHandler(OnChanged);
            //watcher.Created -= new FileSystemEventHandler(OnChanged);
            //watcher.Deleted -= new FileSystemEventHandler(OnChanged);
            watcher.Renamed -= new RenamedEventHandler(OnRenamed);
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            int viruses = 0;

            try
            {
                //StreamReader stream = new StreamReader(e.FullPath);
                //string read = stream.ReadToEnd();
                //string[] virus = new string[] { "VIRUSES", "INFECTED", "HACKED" };
                //List<string> infected = new List<string>();

                RBTree tree = new RBTree();

                string signature_file = Signature.signaturePath;
                tree = Signature.LoadSignatures(signature_file, tree);
                string root_directory = Watcher.watcherPath;
                string search_pattern = "*.*";

                FileInfo size = new FileInfo(e.FullPath);
                //если попавшийся файл - архив
                if (size.Name.Contains(".zip"))
                {
                    Signature.SearchArchive(e.FullPath, tree);
                }
                else if (size.Length < 200000000)
                {

                    Signature.find_sign_in_file(e.FullPath, tree);

                }

                Signature.FindFiles(root_directory, search_pattern, tree);
                if (viruses != 0)
                {
                    Console.WriteLine("файл {0} заражен", e.FullPath);
                    Console.WriteLine("Количество обнаруженных вирусов: {0}", viruses);
                }
                else
                {
                    Console.WriteLine("файл {0} не заражен", e.FullPath);
                }

                //stream.Close();
            }
            catch
            {

            }


        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
