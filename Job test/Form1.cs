using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;

namespace Job_test
{
    public partial class Form1 : Form
    {
        private SQLiteConnection db;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"D:\G:\Projects\VS Code\Job test junior C# developer\Job-test-junior-C-sharp-developer\Job test\bin\Debug\Db.db3"))
            {
                //Do nothing
            }
            else
            {
                db = new SQLiteConnection(@"D:\G:\Projects\VS Code\Job test junior C# developer\Job-test-junior-C-sharp-developer\Job test\bin\Debug\Db.db3");

                db.CreateTable<DBInfo>();

                db.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
