
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace PipeClient
{
    public partial class Form1 : Form
    {
        public OpenFileDialog openFileDialog1;
        public int f;
        public int openObject;
        private Client pipeClient;
        private int viruses =0;

        public Form1()
        {
            InitializeComponent();
            this.pipeClient = new Client();
            this.pipeClient.MessageReceived += 
                new Client.MessageReceivedHandler(pipeClient_MessageReceived);
        }

        void pipeClient_MessageReceived(string message)
        {
            this.Invoke(new Client.MessageReceivedHandler(DisplayReceivedMessage),
                new object[] { message });
        }

        void DisplayReceivedMessage(string message)
        {
            this.tbReceived.Text += message + "\r\n";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.pipeClient.Connected)
            {
                this.pipeClient.PipeName = this.tbPipeName.Text;
                this.pipeClient.Connect();
                this.btnStart.Enabled = false;
            }
            else
                MessageBox.Show("Already connected.");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.pipeClient.SendMessage(this.tbSend.Text, "check_folder");
        }

      

        private void btnPath_Click_1(object sender, EventArgs e)
        {
            openObject = 1;
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSend.Text = folderBrowserDialog1.SelectedPath;
            }
            viruses = 0;
            listBox1.Items.Clear();
            //button2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openObject = 1;
            this.openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ValidateNames = false;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSend.Text = openFileDialog1.FileName;
            }
            viruses = 0;
            listBox1.Items.Clear();
        }

        private void stopWatcher_Click(object sender, EventArgs e)
        {
            this.pipeClient.SendMessage("command", "stop_watcher");
        }

        private void startWatcher_Click(object sender, EventArgs e)
        {
            this.pipeClient.SendMessage("command", "start_watcher");
        }

        
    }
}