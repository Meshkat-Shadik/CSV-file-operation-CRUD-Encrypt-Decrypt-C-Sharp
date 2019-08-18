using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace csv_try
{
    public partial class richtextbox : Form
    {
        string location;
        public richtextbox(string x)
        {
            InitializeComponent();
            location = x;
            method();
        }
        void method()
        {
            //Stream str;
            string filetext = File.ReadAllText(location);
          //  MessageBox.Show(filetext);
            richTextBox1.Text = filetext;
        }
    }


}
