using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

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

        public void GetLastData(float eDL, float eNL, float cWL, float hWL)
        {
            electricDayLast = eDL;
            electricNightLast = eNL;
            coldWaterLast = cWL;
            hotWaterLast = hWL;
        }
    }
}
