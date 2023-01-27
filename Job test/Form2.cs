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
    public partial class Form2 : Form
    {
        private SQLiteConnection db;

        Maths maths { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
