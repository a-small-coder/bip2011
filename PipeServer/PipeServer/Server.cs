using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO.Compression;


namespace PipeServer
{
    class Server
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateNamedPipe(
           String pipeName,
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes);
        private int viruses = 0;
        [DllImport("kernel32.dll", SetLastError = true)]

        public static extern int ConnectNamedPipe(
           SafeFileHandle hNamedPipe,
           IntPtr lpOverlapped);

        public const uint DUPLEX = (0x00000003);
        public const uint FILE_FLAG_OVERLAPPED = (0x40000000);

        public class Client
        {
            public SafeFileHandle handle;
            public FileStream stream;
        }

        public delegate void MessageReceivedHandler(Client client, string message);

        public event MessageReceivedHandler MessageReceived;
        public const int BUFFER_SIZE = 4096;

        string pipeName;
        Thread listenThread;
        bool running;
        List<Client> clients;

        public string PipeName
        {
            get { return this.pipeName; }
            set { this.pipeName = value; }
        }

        public bool Running
        {
            get { return this.running; }
        }

        public Server()
        {
            this.clients = new List<Client>();
        }

        /// <summary>
        /// Starts the pipe server
        /// </summary>
        public void Start()
        {
            //start the listening thread
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();

            this.running = true;
        }

        /// <summary>
        /// Listens for client connections
        /// </summary>
        private void ListenForClients()
        {
            while (true)
            {
                SafeFileHandle clientHandle =
                CreateNamedPipe(
                     this.pipeName,
                     DUPLEX | FILE_FLAG_OVERLAPPED,
                     0,
                     255,
                     BUFFER_SIZE,
                     BUFFER_SIZE,
                     0,
                     IntPtr.Zero);

                //could not create named pipe
                if (clientHandle.IsInvalid)
                    return;

                int success = ConnectNamedPipe(clientHandle, IntPtr.Zero);

                //could not connect client
                if (success == 0)
                    return;

                Client client = new Client();
                client.handle = clientHandle;

                lock (clients)
                    this.clients.Add(client);

                Thread readThread = new Thread(new ParameterizedThreadStart(Read));
                readThread.Start(client);
            }
        }

        /// <summary>
        /// Reads incoming data from connected clients
        /// </summary>
        /// <param name="clientObj"></param>
        private void Read(object clientObj)
        {
            Client client = (Client)clientObj;
            client.stream = new FileStream(client.handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
            byte[] buffer = new byte[BUFFER_SIZE];
            ASCIIEncoding encoder = new ASCIIEncoding();
            while (true)
            {
                int bytesRead = 0;

                try
                {
                    bytesRead = client.stream.Read(buffer, 0, BUFFER_SIZE);
                }
                catch
                {
                    //read error has occurred
                    break;
                }

                //client has disconnected
                if (bytesRead == 0)
                    break;

                //fire message received event
                if (this.MessageReceived != null)
                    this.MessageReceived(client, encoder.GetString(buffer, 0, bytesRead));

                string messageBuffer = encoder.GetString(buffer, 0, bytesRead);
                string[] path_command = messageBuffer.Split(' ');
                switch (path_command[1])
                {
                    case "check_folder":
                        RBTree tree = new RBTree();


                        string signature_file = Signature.signaturePath;
                        tree = Signature.LoadSignatures(signature_file, tree);
                        string root_directory = path_command[0];// @"C:\Users\Lenovo\Desktop";
                        string search_pattern = "*.*";
                        Signature.clearScanResults();

                        Signature.FindFiles(root_directory, search_pattern, tree, this.SendMessage);
                        SendMessage("Scanning done" + Environment.NewLine);
                        SendMessage("Count of scanning files: " + Signature.numScanFiles.ToString() + Environment.NewLine);
                        SendMessage("Threats detected: " + Signature.VirusCount.ToString() + Environment.NewLine);
                        if (Signature.VirusCount > 0)
                        {
                            SendMessage("Detected and eliminated threats below:" + Environment.NewLine);
                            foreach (string element in Signature.virusFiles)
                            {
                                SendMessage(element + Environment.NewLine); // выводим каждый элемент на консоль
                            }
                        }
                        break;
                    case "move_to_qurantine":
                        SendMessage("File moved to quarantine: " + Environment.NewLine + path_command[0] + Environment.NewLine);
                        Signature.MoveToQuarantine(path_command[0]);
                        break;
                    case "recover_file":
                        Signature.Recover(path_command[0]);
                        break;
                    case "stop_watcher":
                        Watcher.Stop();
                        SendMessage("Watcher disabled");
                        break;
                    case "start_watcher":
                        Watcher.Run();
                        Console.WriteLine("Restart Watcher");
                        break;
                    default:
                        Console.WriteLine("Что-то не то с командами");
                        break;
                }
                Console.WriteLine(messageBuffer);
            }

            //clean up resources
            client.stream.Close();
            client.handle.Close();
            lock (this.clients)
                this.clients.Remove(client);
        }

        /// <summary>
        /// Sends a message to all connected clients
        /// </summary>
        /// <param name="message">the message to send</param>
        public int SendMessage(string message)
        {
            lock (this.clients)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] messageBuffer = encoder.GetBytes(message);
                foreach (Client client in this.clients)
                {
                    client.stream.Write(messageBuffer, 0, messageBuffer.Length);
                    client.stream.Flush();
                }
            }
            return 1;
        }


    }
}
