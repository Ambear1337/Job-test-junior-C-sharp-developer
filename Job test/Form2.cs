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
    public partial class Form2 : Form
    {
        Maths maths { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Calculate();
        }

        public void Calculate()
        {
            

            /*if (isElectricMeter)
            {
                float vDay = electricDay - electricDayLast;
                float vNight = electricNight - electricNightLast;

                electricMoney = (vDay*)+(vNight * electricNightRate);
            }
            else
            {
                electricMoney = people * electricNorm;
            }

            if (isColdWaterMeter)
            {
                float v = coldWater - coldWaterLast;

                coldWaterMoney = v * coldWaterRate;
            }
            else
            {
                coldWaterMoney = people * coldWaterNorm;
            }

            if (isHotWaterMeter)
            {
                float vHeatCarrier = hotWater - hotWaterLast;
                float vHeatEnergy = vHeatCarrier * heatCarrierNorm;

                heatCarrierMoney = vHeatCarrier * heatCarrierRate;
                heatEnergyMoney = vHeatEnergy * heatEnergyRate;
            }
            else
            {
                heatCarrierMoney = people * heatCarrierNorm;
                heatEnergyMoney = people * heatEnergyNorm;
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
