using Microsoft.SqlServer.Server;
using PipeServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace AntivirusService
{
    public partial class Service1 : ServiceBase
    {
        private Server pipeServer;
        public Service1()
        {
            InitializeComponent();
            this.pipeServer = new Server();

            this.pipeServer.MessageReceived +=
                new Server.MessageReceivedHandler(pipeServer_MessageReceived);
        }

        void pipeServer_MessageReceived(Server.Client client, string message)
        {
            WriteToFile(message + "\r\n");
        }

        //public static Thread watcherThread;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        protected override void OnStart(string[] args)
        {
            Watcher.Start();
            if (!this.pipeServer.Running)
            {
                this.pipeServer.PipeName = "C:\\temp\\\\.\\pipe\\myNamedPipe";
                this.pipeServer.Start();
                WriteToFile("Server is running.");
            }
            else
                WriteToFile("Server already running.");
        }
        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
