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

namespace csv_try
{
    public partial class Form2 : Form
    {
        string picloc,p2;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

       /*     FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picloc = dlg.SelectedPath.ToString();
                MessageBox.Show(picloc);
                //pictureBox1.ImageLocation = picloc;
            }*/

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save the File";
            save.Filter = "CSV File|*.csv|Text Files|*.txt|All Files|*.*";
            if(save.ShowDialog() == DialogResult.OK)

            {
               
                using (Stream s = File.Open(save.FileName, FileMode.CreateNew))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        
                    }
                }
            }
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*";
            dlg.Title = "Select File";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picloc = dlg.FileName.ToString();
                label1.Text = picloc;
            }
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*";
            dlg.Title = "Select File";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                p2 = dlg.FileName.ToString();
                //label1.Text = picloc;
            }
            button3.Visible = true;
            Form1 obj = new Form1(p2);
            obj.Show();
        }
    }
}
