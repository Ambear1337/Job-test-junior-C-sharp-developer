using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
            db = new SQLiteConnection("Data Source=Db.db; Version=3");
            db.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Close();
        }
    }
}
