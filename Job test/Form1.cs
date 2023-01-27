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
        int people;

        bool isColdWater;
        bool isHotWater;
        bool isElectric;

        float coldWater;
        float hotWater;
        float electricDay;
        float electricNight;

        public Form1()
        {
            InitializeComponent();

            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            people = Int32.Parse(textBox1.Text);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            isColdWater = checkBox3.Checked;

            if (checkBox3.Checked)
            {
                textBox5.Show();
            }
            else
            {
                textBox5.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isHotWater = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                textBox2.Show();
            }
            else
            {
                textBox2.Hide();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isElectric = checkBox2.Checked;

            if (checkBox2.Checked)
            {
                textBox3.Show();
                textBox4.Show();
            }
            else
            {
                textBox3.Hide();
                textBox4.Hide();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            coldWater = float.Parse(textBox5.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            hotWater = float.Parse(textBox2.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            electricDay = float.Parse(textBox4.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            electricNight = float.Parse(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Maths maths = new Maths(electricDay, electricNight, coldWater, hotWater, isElectric,isHotWater, isColdWater, people);

            maths.Calculate();
        }
    }
}
