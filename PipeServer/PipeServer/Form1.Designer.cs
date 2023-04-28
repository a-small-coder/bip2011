namespace PipeServer
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
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.lblPipeName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblReceived = new System.Windows.Forms.Label();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(12, 29);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(217, 20);
            this.tbPipeName.TabIndex = 0;
            this.tbPipeName.Text = "\\\\.\\pipe\\myNamedPipe";
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.Location = new System.Drawing.Point(12, 13);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(72, 15);
            this.lblPipeName.TabIndex = 1;
            this.lblPipeName.Text = "Pipe Name:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(235, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(12, 88);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(298, 86);
            this.tbSend.TabIndex = 3;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(12, 72);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(93, 15);
            this.lblSend.TabIndex = 4;
            this.lblSend.Text = "Send Message:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(235, 180);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(12, 199);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(121, 15);
            this.lblReceived.TabIndex = 7;
            this.lblReceived.Text = "Received Messages:";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(12, 215);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.Size = new System.Drawing.Size(298, 86);
            this.tbReceived.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 383);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(310, 69);
            this.listBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "VIRUUSEEES";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPipeName);
            this.Controls.Add(this.tbPipeName);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Label lblPipeName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

