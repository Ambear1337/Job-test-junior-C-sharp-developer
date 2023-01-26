using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Тарифы
        const float coldWaterRate = 35.78f;
        const float hotWaterRate = 158.98f;
        const float heatCarrierRate = 35.78f;
        const float heatEnergyRate = 998.69f;
        const float electricRate = 4.28f;
        const float electricDayRate = 4.9f;
        const float electricNightRate = 2.31f;

        //Нормативы
        const float coldWaterNorm = 4.85f;
        const float hotWaterNorm = 4.01f;
        const float electricNorm = 164f;
        const float heatCarrierNorm = 4.01f;
        const float heatEnergyNorm = 0.05349f;

        //Расчеты
        private float electricMoney;
        private float coldWaterMoney;
        private float heatCarrierMoney;
        private float heatEnergyMoney;

        public Maths() { }

        Maths(float eD, float eN, float cW, float hW)
        {
            electricDay = eD;
            electricNight = eN;
            coldWater = cW;
            hotWater = hW;
        }

        public void Calculate()
        {
            if (isElectricMeter)
            {
                float vDay = electricDay - electricDayLast;
                float vNight = electricNight - electricNightLast;

                electricMoney = (vDay * electricDayRate) + (vNight * electricNightRate);
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
