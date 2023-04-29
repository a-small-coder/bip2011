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
            this.tbPipeName.Location = new System.Drawing.Point(16, 36);
            this.tbPipeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(288, 22);
            this.tbPipeName.TabIndex = 0;
            this.tbPipeName.Text = "\\\\.\\pipe\\myNamedPipe";
            this.tbPipeName.TextChanged += new System.EventHandler(this.tbPipeName_TextChanged);
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.Location = new System.Drawing.Point(16, 16);
            this.lblPipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(78, 16);
            this.lblPipeName.TabIndex = 1;
            this.lblPipeName.Text = "Pipe Name:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(313, 33);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(16, 108);
            this.tbSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(396, 105);
            this.tbSend.TabIndex = 3;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(16, 89);
            this.lblSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(102, 16);
            this.lblSend.TabIndex = 4;
            this.lblSend.Text = "Send Message:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(313, 222);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(16, 245);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(136, 16);
            this.lblReceived.TabIndex = 7;
            this.lblReceived.Text = "Received Messages:";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(16, 265);
            this.tbReceived.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.Size = new System.Drawing.Size(396, 105);
            this.tbReceived.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 471);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(412, 84);
            this.listBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 438);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "VIRUUSEEES";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 606);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
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

