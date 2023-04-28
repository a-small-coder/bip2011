namespace PipeClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblReceived = new System.Windows.Forms.Label();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSend = new System.Windows.Forms.Label();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPipeName = new System.Windows.Forms.Label();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.GetPathFolder = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.stopWatcher = new System.Windows.Forms.Button();
            this.startWatcher = new System.Windows.Forms.Button();
            this.GetPathFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(16, 362);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(136, 16);
            this.lblReceived.TabIndex = 15;
            this.lblReceived.Text = "Received Messages:";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(19, 395);
            this.tbReceived.Margin = new System.Windows.Forms.Padding(4);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.Size = new System.Drawing.Size(396, 105);
            this.tbReceived.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(298, 328);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Check";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(10, 184);
            this.lblSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(102, 16);
            this.lblSend.TabIndex = 12;
            this.lblSend.Text = "Send Message:";
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(17, 215);
            this.tbSend.Margin = new System.Windows.Forms.Padding(4);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(396, 105);
            this.tbSend.TabIndex = 11;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(313, 28);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Connect";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.Location = new System.Drawing.Point(16, 11);
            this.lblPipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(78, 16);
            this.lblPipeName.TabIndex = 9;
            this.lblPipeName.Text = "Pipe Name:";
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(16, 31);
            this.tbPipeName.Margin = new System.Windows.Forms.Padding(4);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(288, 22);
            this.tbPipeName.TabIndex = 8;
            this.tbPipeName.Text = "\\\\.\\pipe\\myNamedPipe";
            // 
            // GetPathFolder
            // 
            this.GetPathFolder.Location = new System.Drawing.Point(141, 328);
            this.GetPathFolder.Margin = new System.Windows.Forms.Padding(4);
            this.GetPathFolder.Name = "GetPathFolder";
            this.GetPathFolder.Size = new System.Drawing.Size(100, 28);
            this.GetPathFolder.TabIndex = 16;
            this.GetPathFolder.Text = "pick folder";
            this.GetPathFolder.UseVisualStyleBackColor = true;
            this.GetPathFolder.Click += new System.EventHandler(this.btnPath_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(19, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(492, 116);
            this.listBox1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 551);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Selected folder:";
            // 
            // stopWatcher
            // 
            this.stopWatcher.Location = new System.Drawing.Point(451, 26);
            this.stopWatcher.Margin = new System.Windows.Forms.Padding(4);
            this.stopWatcher.Name = "stopWatcher";
            this.stopWatcher.Size = new System.Drawing.Size(139, 28);
            this.stopWatcher.TabIndex = 19;
            this.stopWatcher.Text = "Stop Watcher";
            this.stopWatcher.UseVisualStyleBackColor = true;
            this.stopWatcher.Click += new System.EventHandler(this.stopWatcher_Click);
            // 
            // startWatcher
            // 
            this.startWatcher.Location = new System.Drawing.Point(451, 212);
            this.startWatcher.Margin = new System.Windows.Forms.Padding(4);
            this.startWatcher.Name = "startWatcher";
            this.startWatcher.Size = new System.Drawing.Size(139, 28);
            this.startWatcher.TabIndex = 20;
            this.startWatcher.Text = "Start Watcher";
            this.startWatcher.UseVisualStyleBackColor = true;
            this.startWatcher.Click += new System.EventHandler(this.startWatcher_Click);
            // 
            // GetPathFile
            // 
            this.GetPathFile.Location = new System.Drawing.Point(19, 328);
            this.GetPathFile.Margin = new System.Windows.Forms.Padding(4);
            this.GetPathFile.Name = "GetPathFile";
            this.GetPathFile.Size = new System.Drawing.Size(100, 28);
            this.GetPathFile.TabIndex = 21;
            this.GetPathFile.Text = "pick file";
            this.GetPathFile.UseVisualStyleBackColor = true;
            this.GetPathFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 632);
            this.Controls.Add(this.GetPathFile);
            this.Controls.Add(this.startWatcher);
            this.Controls.Add(this.stopWatcher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.GetPathFolder);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPipeName);
            this.Controls.Add(this.tbPipeName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPipeName;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Button GetPathFolder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button stopWatcher;
        private System.Windows.Forms.Button startWatcher;
        private System.Windows.Forms.Button GetPathFile;
    }
}

