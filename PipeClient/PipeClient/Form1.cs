
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
        private int viruses = 0;
        private static bool isRun = false;
        string QuarantinePath = "C:\\Quarantine";

        public Form1()
        {
            InitializeComponent();
            this.pipeClient = new Client();
            this.pipeClient.MessageReceived += 
                new Client.MessageReceivedHandler(pipeClient_MessageReceived);
            this.listBox1.Items.Clear();
            PopulateListBox(this.listBox1, QuarantinePath, "*.other");
            this.label4.Visible = false;
        }

        void pipeClient_MessageReceived(string message)
        {
            this.Invoke(new Client.UpdateListBoxHandler(PopulateListBox2));
            this.Invoke(new Client.MessageReceivedHandler(DisplayReceivedMessage),
                new object[] { message });
        }

        void DisplayReceivedMessage(string message)
        {
            if (isRun)
            {
                this.tbReceived.Text += message + "\r\n";
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.pipeClient.Connected)
            {
                this.pipeClient.PipeName = "\\\\.\\pipe\\myNamedPipe";
                this.pipeClient.Connect();
                this.btnStart.Enabled = false;
                isRun = true;
                this.label4.Visible = true;
                this.label5.Visible = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            tbReceived.Text = "";
            if (isRun)
            {
                this.pipeClient.SendMessage(this.tbSend.Text, "check_folder");
            }
           
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
            //button2.Show();
        }

        private void stopWatcher_Click(object sender, EventArgs e)
        {
            this.pipeClient.SendMessage("command", "stop_watcher");
        }

        private void startWatcher_Click(object sender, EventArgs e)
        {
            this.pipeClient.SendMessage("command", "start_watcher");
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            openObject = 1;
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSend.Text = openFileDialog1.FileName;
            }
            
            viruses = 0;
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openRecoverFile = new OpenFileDialog();
            openRecoverFile.InitialDirectory = QuarantinePath;
            if (openRecoverFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                tbSend.Text = Path.GetFileName(openRecoverFile.FileName);
                
                this.pipeClient.SendMessage(this.tbSend.Text, "recover_file");
            }
        }

        private void btnMoveToQuarantine_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openQFile = new OpenFileDialog();
            openQFile.InitialDirectory = "C:\\viruses";
            if (openQFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                tbSend.Text = openQFile.FileName;
                this.pipeClient.SendMessage(this.tbSend.Text, "move_to_qurantine");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblSend_Click(object sender, EventArgs e)
        {

        }

        private void tbSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            isRun = false;
            this.label5.Visible = true;
            this.label4.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles();
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }
        private void PopulateListBox2()
        {
            this.listBox1.Items.Clear();
            PopulateListBox(this.listBox1, QuarantinePath, "*.other");
        }
    }
}