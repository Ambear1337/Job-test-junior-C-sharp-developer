using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Job_test
{
    class Maths
    {
        //Предыдущие значения счетчиков
        private float electricDayLast = 0f;
        private float electricNightLast = 0f;
        private float coldWaterLast = 0f;
        private float hotWaterLast = 0f;

        //Данные текущие значения счетчиков
        private float electricDay = 0f;
        private float electricNight = 0f;
        private float coldWater = 0f;
        private float hotWater = 0f;

        //Количество людей в помещении
        private int people = 1;

        //Наличие счетчиков
        private bool isElectricMeter = false;
        private bool isHotWaterMeter = false;
        private bool isColdWaterMeter = false;

        //Расчеты
        private float electricMoney;
        private float coldWaterMoney;
        private float heatCarrierMoney;
        private float heatEnergyMoney;

        public Maths(float eD, float eN, float cW, float hW, bool eM, bool hWM, bool cWM, int p)
        {
            electricDay = eD;
            electricNight = eN;
            coldWater = cW;
            hotWater = hW;

            isElectricMeter = eM;
            isHotWaterMeter = hWM;
            isColdWaterMeter = cWM;

            people = p;
        }

        public void Calculate()
        {
            SQLiteConnection source = new SQLiteConnection(@"D:\G:\Projects\VS Code\Job test junior C# developer\Job-test-junior-C-sharp-developer\Job test\bin\Debug\SourceDb.db3");
            source.Open();

            string query = "SELECT* from Student";
            SQLiteCommand cmd = new SQLiteCommand(query, source);

            DataTable dt = new DataTable();

            if (isElectricMeter)
            {
                float vDay = electricDay - electricDayLast;
                float vNight = electricNight - electricNightLast;

                electricMoney = (vDay * ) + (vNight * electricNightRate);
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
            }
        }

        public void GetLastData(float eDL, float eNL, float cWL, float hWL)
        {
            electricDayLast = eDL;
            electricNightLast = eNL;
            coldWaterLast = cWL;
            hotWaterLast = hWL;
        }
    }
}
