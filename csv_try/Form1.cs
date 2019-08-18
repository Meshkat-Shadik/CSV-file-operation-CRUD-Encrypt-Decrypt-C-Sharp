using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
namespace csv_try
{
    public partial class Form1 : Form
    {
        int count = 0;
        string picloc;
        string key = "meshkatt";
        public Form1(string p)
        {
            InitializeComponent();
            picloc = p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richtextbox obj = new richtextbox(picloc);
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(@picloc))
                {
                    sw.WriteLine(textBox1.Text + "," + textBox2.Text + "," + textBox3.Text);
                    MessageBox.Show("Saved Successfully!");
                    clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void clear()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox1.Focus();       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count++;
            if (label5 != null)
              label5.Text = count.ToString();   
            EncryptFile(picloc, key);
        }


       static void EncryptFile(string filepath, string key)
        {
             try
           {
            byte[] all = File.ReadAllBytes(filepath);
           using (var DES = new DESCryptoServiceProvider())
           {
               DES.IV = Encoding.UTF8.GetBytes(key);
               DES.Key = Encoding.UTF8.GetBytes(key);
               DES.Mode = CipherMode.CBC;
               DES.Padding = PaddingMode.PKCS7;
               
               using(var mem = new MemoryStream())
               {
                   CryptoStream cryptostream = new CryptoStream(mem, DES.CreateEncryptor(), CryptoStreamMode.Write);
                   cryptostream.Write(all, 0, all.Length);
                   cryptostream.FlushFinalBlock();
                   File.WriteAllBytes(filepath, mem.ToArray());
                   MessageBox.Show("Encrypted!");
               }
           }
           }
             catch (Exception ex)
             {
                 MessageBox.Show("Already Encrypted!!" + ex.Message);
             }
        }
       static void DescryptFile(string filepath, string key)
       {
           try
           {
               byte[] all = File.ReadAllBytes(filepath);
               using (var DES = new DESCryptoServiceProvider())
               {
                   DES.IV = Encoding.UTF8.GetBytes(key);
                   DES.Key = Encoding.UTF8.GetBytes(key);
                   DES.Mode = CipherMode.CBC;
                   DES.Padding = PaddingMode.PKCS7;

                   using (var mem = new MemoryStream())
                   {
                       CryptoStream cryptostream = new CryptoStream(mem, DES.CreateDecryptor(), CryptoStreamMode.Write);
                       cryptostream.Write(all, 0, all.Length);
                       cryptostream.FlushFinalBlock();
                       File.WriteAllBytes(filepath, mem.ToArray());
                       MessageBox.Show("Descrypted!");
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Already Dycrypted!!"+ex.Message);
           }
       }

       private void button4_Click(object sender, EventArgs e)
       {
           count--;
           if (label5 != null)
               label5.Text = count.ToString(); 
           DescryptFile(picloc, key);
       }

       private void button5_Click(object sender, EventArgs e)
       {
           show obj = new show(picloc);
           obj.ShowDialog();
       }

       private void Form1_Load(object sender, EventArgs e)
       {
           this.Show();
       }
  

        //CSV = comma separated values
    }
}


/*
         OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picloc = dlg.FileName.ToString();
                label4.Text = picloc;
                //pictureBox1.ImageLocation = picloc;
            }
*/