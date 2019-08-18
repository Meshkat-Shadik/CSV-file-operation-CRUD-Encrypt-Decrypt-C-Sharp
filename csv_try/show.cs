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
using Microsoft.VisualBasic.FileIO;

namespace csv_try
{
    public partial class show : Form
    {
        string path;
        public show(string x)
        {
            InitializeComponent();
            path = x;
            method1();
        }


     /*   void method()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Dept");
            try
            {
                using (var reader = new StreamReader(@path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        dt.Rows.Add(new object[] { values[0], values[1], values[2] });
                    }
                }
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      */
        void method1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Dept");
            try
            {
                using (TextFieldParser reader = new TextFieldParser(@path))
                {
                    reader.SetDelimiters(new String[] { "," });
                    reader.HasFieldsEnclosedInQuotes = true;
                    while (!reader.EndOfData)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        dt.Rows.Add(new object[] { values[0], values[1], values[2] });
                    }
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
