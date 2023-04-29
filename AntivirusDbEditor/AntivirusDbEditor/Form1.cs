using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntivirusDbEditor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void textMain_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\hulkt\\OneDrive\\Документы\\antivirus\\PipeServer\\signature.txt";
            // асинхронное чтение
            //using (StreamReader reader = new StreamReader(path))
            //{
            textMain.Text = "";
                string[] text = File.ReadAllLines(path);
                for( int i=0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    textMain.Text += text[i][j];
                }
                textMain.Text += Environment.NewLine;
            }
                Console.WriteLine(text);
            //}
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string text = textMain.Text;
            string path = "C:\\Users\\hulkt\\OneDrive\\Документы\\antivirus\\PipeServer\\newSignature.txt";
            // асинхронное чтение
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write("");
                writer.Write(text);
                textMain.Text = "";
                Console.WriteLine(text);
            }
        }
    }
}
