
namespace AntivirusDbEditor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textMain = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textMain
            // 
            this.textMain.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textMain.Location = new System.Drawing.Point(29, 78);
            this.textMain.Multiline = true;
            this.textMain.Name = "textMain";
            this.textMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textMain.Size = new System.Drawing.Size(1118, 412);
            this.textMain.TabIndex = 0;
            this.textMain.WordWrap = false;
            this.textMain.TextChanged += new System.EventHandler(this.textMain_TextChanged);
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.SystemColors.Info;
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRead.Location = new System.Drawing.Point(29, 510);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(300, 53);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Загрузить сигнатуры";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.MaximumSize = new System.Drawing.Size(1732, 50);
            this.label1.MinimumSize = new System.Drawing.Size(732, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1118, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "OFFSETBEGIN       ;        BYTE        ;       DTYPE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.SystemColors.Info;
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWrite.Location = new System.Drawing.Point(847, 510);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(300, 53);
            this.btnWrite.TabIndex = 3;
            this.btnWrite.Text = "Записать сигнатуры";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1159, 584);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.textMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ANTIVIRUS Db EDITOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textMain;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWrite;
    }
}

