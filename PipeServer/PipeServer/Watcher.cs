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

    {   public static string[] viruses_paths;
        public static FileSystemWatcher watcher;
        public static string watcherPath = "C:\\viruses";
        public static Func<string, int> SendMessage;
        public static void Start()
        {
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = Watcher.watcherPath;
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            SendMessage("Watcher started...");
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

        }

        public static void Stop()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Changed -= new FileSystemEventHandler(OnChanged);
            watcher.Created -= new FileSystemEventHandler(OnChanged);
            //watcher.Deleted -= new FileSystemEventHandler(OnChanged);
            //watcher.Renamed -= new RenamedEventHandler(OnRenamed);
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            int viruses = 0;

            try
            {

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
                List<string> infected = new List<string>();

                Signature.FindFiles(root_directory, search_pattern, tree, Watcher.CasperSendMessage);
                if (Signature.VirusCount != 0)
                {
                    SendMessage("file is infected:");
                    SendMessage(e.FullPath);
                    SendMessage("viruses in file: " + Signature.VirusCount.ToString());
                    infected.Add(e.FullPath);

                }
                else
                {
                    SendMessage("file is clear:");
                    SendMessage(e.FullPath);
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
            SendMessage("File: " + e.OldFullPath + " renamed to " + e.FullPath);
        }

        public static int CasperSendMessage(string message)
        {
            return 1;
        }
    }
}
