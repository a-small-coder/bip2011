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
            this.GetPathFolder = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.stopWatcher = new System.Windows.Forms.Button();
            this.startWatcher = new System.Windows.Forms.Button();
            this.GetPathFile = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.btnMoveToQuarantine = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblReceived.ForeColor = System.Drawing.Color.White;
            this.lblReceived.Location = new System.Drawing.Point(18, 231);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(338, 29);
            this.lblReceived.TabIndex = 15;
            this.lblReceived.Text = "Результаты сканирования:";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(23, 273);
            this.tbReceived.Margin = new System.Windows.Forms.Padding(4);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.Size = new System.Drawing.Size(868, 347);
            this.tbReceived.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Orange;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(495, 195);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(396, 48);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Запустить проверку";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSend.ForeColor = System.Drawing.Color.White;
            this.lblSend.Location = new System.Drawing.Point(490, 22);
            this.lblSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(380, 29);
            this.lblSend.TabIndex = 12;
            this.lblSend.Text = "Выбор пути для сканирования";
            this.lblSend.Click += new System.EventHandler(this.lblSend_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(495, 68);
            this.tbSend.Margin = new System.Windows.Forms.Padding(4);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(396, 48);
            this.tbSend.TabIndex = 11;
            this.tbSend.TextChanged += new System.EventHandler(this.tbSend_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkCyan;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(13, 68);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(227, 71);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Запуск сервиса";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPipeName.ForeColor = System.Drawing.Color.White;
            this.lblPipeName.Location = new System.Drawing.Point(13, 22);
            this.lblPipeName.Margin = new System.Windows.Forms.Padding(4);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(251, 29);
            this.lblPipeName.TabIndex = 9;
            this.lblPipeName.Text = "Состояние сервиса";
            // 
            // GetPathFolder
            // 
            this.GetPathFolder.BackColor = System.Drawing.Color.Ivory;
            this.GetPathFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GetPathFolder.FlatAppearance.BorderSize = 0;
            this.GetPathFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetPathFolder.ForeColor = System.Drawing.Color.Black;
            this.GetPathFolder.Location = new System.Drawing.Point(704, 133);
            this.GetPathFolder.Margin = new System.Windows.Forms.Padding(4);
            this.GetPathFolder.Name = "GetPathFolder";
            this.GetPathFolder.Size = new System.Drawing.Size(187, 48);
            this.GetPathFolder.TabIndex = 16;
            this.GetPathFolder.Text = "pick folder";
            this.GetPathFolder.UseVisualStyleBackColor = false;
            this.GetPathFolder.Click += new System.EventHandler(this.btnPath_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(943, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(670, 404);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(944, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Папка \"Карантин\":";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // stopWatcher
            // 
            this.stopWatcher.BackColor = System.Drawing.Color.Orange;
            this.stopWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopWatcher.ForeColor = System.Drawing.Color.Black;
            this.stopWatcher.Location = new System.Drawing.Point(583, 628);
            this.stopWatcher.Margin = new System.Windows.Forms.Padding(4);
            this.stopWatcher.Name = "stopWatcher";
            this.stopWatcher.Size = new System.Drawing.Size(308, 48);
            this.stopWatcher.TabIndex = 19;
            this.stopWatcher.Text = "Остановить мониторинг";
            this.stopWatcher.UseVisualStyleBackColor = false;
            this.stopWatcher.Click += new System.EventHandler(this.stopWatcher_Click);
            // 
            // startWatcher
            // 
            this.startWatcher.BackColor = System.Drawing.Color.Orange;
            this.startWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startWatcher.ForeColor = System.Drawing.Color.Black;
            this.startWatcher.Location = new System.Drawing.Point(23, 628);
            this.startWatcher.Margin = new System.Windows.Forms.Padding(4);
            this.startWatcher.Name = "startWatcher";
            this.startWatcher.Size = new System.Drawing.Size(295, 48);
            this.startWatcher.TabIndex = 20;
            this.startWatcher.Text = "Запустить мониторинг";
            this.startWatcher.UseVisualStyleBackColor = false;
            this.startWatcher.Click += new System.EventHandler(this.startWatcher_Click);
            // 
            // GetPathFile
            // 
            this.GetPathFile.BackColor = System.Drawing.Color.Ivory;
            this.GetPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetPathFile.ForeColor = System.Drawing.Color.Black;
            this.GetPathFile.Location = new System.Drawing.Point(495, 133);
            this.GetPathFile.Margin = new System.Windows.Forms.Padding(4);
            this.GetPathFile.Name = "GetPathFile";
            this.GetPathFile.Size = new System.Drawing.Size(201, 48);
            this.GetPathFile.TabIndex = 21;
            this.GetPathFile.Text = "pick file";
            this.GetPathFile.UseVisualStyleBackColor = false;
            this.GetPathFile.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.BackColor = System.Drawing.Color.Ivory;
            this.btnRecover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRecover.ForeColor = System.Drawing.Color.Black;
            this.btnRecover.Location = new System.Drawing.Point(1281, 68);
            this.btnRecover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(330, 48);
            this.btnRecover.TabIndex = 25;
            this.btnRecover.Text = "Восстановить из карантина";
            this.btnRecover.UseVisualStyleBackColor = false;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnMoveToQuarantine
            // 
            this.btnMoveToQuarantine.BackColor = System.Drawing.Color.Ivory;
            this.btnMoveToQuarantine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMoveToQuarantine.ForeColor = System.Drawing.Color.Black;
            this.btnMoveToQuarantine.Location = new System.Drawing.Point(943, 68);
            this.btnMoveToQuarantine.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveToQuarantine.Name = "btnMoveToQuarantine";
            this.btnMoveToQuarantine.Size = new System.Drawing.Size(330, 48);
            this.btnMoveToQuarantine.TabIndex = 24;
            this.btnMoveToQuarantine.Text = "Поместить в карантин";
            this.btnMoveToQuarantine.UseVisualStyleBackColor = false;
            this.btnMoveToQuarantine.Click += new System.EventHandler(this.btnMoveToQuarantine_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(248, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 71);
            this.button1.TabIndex = 26;
            this.button1.Text = "Остановка сервиса";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(943, 181);
            this.label2.MaximumSize = new System.Drawing.Size(1732, 50);
            this.label2.MinimumSize = new System.Drawing.Size(200, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(668, 50);
            this.label2.TabIndex = 28;
            this.label2.Text = "Просмотр карантина:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(272, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 29);
            this.label4.TabIndex = 29;
            this.label4.Text = "работает";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(321, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 29);
            this.label5.TabIndex = 30;
            this.label5.Text = "остановлен";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1625, 689);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnMoveToQuarantine);
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
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Button GetPathFolder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button stopWatcher;
        private System.Windows.Forms.Button startWatcher;
        private System.Windows.Forms.Button GetPathFile;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Button btnMoveToQuarantine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

