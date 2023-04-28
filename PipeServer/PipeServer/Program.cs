using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace PipeServer
{
    static class Program
    {

        //public static Thread watcherThread;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {

            Watcher.Start();
            //departWatcher("start");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //public static void departWatcher(string action)
        //{
        //    Console.WriteLine("im first wather!!");
        //    Watcher watch = new Watcher();
        //    Thread thread_watcher = new Thread(new ThreadStart(watch.Start));
        //    if (action == "start")
        //    {
        //        thread_watcher.Start();
        //    }
        //    else if (action == "stop")
        //    {
        //        thread_watcher.Abort();
        //    }
        //    else 
        //    {
        //        Console.WriteLine("somthing wrong with wather threds");
        //    }
          
        //}

        //public static void Stop()
        //{
        //    // tread waiting
        //    if (!(Program.watcherThread is null))
        //    {
        //        watcherThread.Interrupt();
        //        Console.WriteLine("Watcher killed");
        //    }

            
        //}

    }
}