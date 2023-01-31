using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Job_test
{
    static class Program
    {
        const string dbSourceFile = "URI=file:Source.db";
        const string dbCalculationsFile = "URI=file:Calculations.db";

        static bool IsColdWater = false;
        static bool IsHotWater = false;
        static bool IsElectric = false;

        static float currentColdWater;
        static float currentHotWater;
        static float currentElectric;

        static float previousColdWater;
        static float previousHotWater;
        static float previousElectric;

        static int people = 1;

        static int answer;

        [STAThread]
        static void Main()
        {
            Start();
        }

        static void CreateTable()
        {
            SQLiteConnection connection = new SQLiteConnection(dbSourceFile);
            connection.Open();
            string tbl = "CREATE TABLE Source (ID integer primary key, SERVICE text, RATE text, NORM text);";
            SQLiteCommand command = new SQLiteCommand(tbl, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        static void AddRow()
        {
            SQLiteConnection connection = new SQLiteConnection(dbSourceFile);
            connection.Open();
            string addService = "INSERT into Source (ID, SERVICE, RATE, NORM) values (1, 'ХВС', '35.78', '4.85');";
            SQLiteCommand command = new SQLiteCommand(addService, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Row added successfully");
            Console.ReadLine();
        }

        static int Choose(string text)
        {
            int answer = 0;

            while (answer != 1 & answer != 2)
            {
                Console.WriteLine(text);
                int.TryParse(Console.ReadLine(), out answer);
            }

            return answer;
        }

        static void Start()
        {
            Console.WriteLine("Расчет оплаты ЖКХ");

            Console.WriteLine(" ");

            Console.WriteLine("Имеется ли у Вас прибор учета по услуге ХВС?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            answer = Choose("Напишите '1' или '2'.");
            if (answer == 1)
                IsColdWater = true;
            else if (answer == 2)
                IsColdWater = false;
            else
                return;

            Console.WriteLine(" ");

            Console.WriteLine("Имеется ли у Вас прибор учета по услуге ГВС?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");

            answer = Choose("Напишите '1' или '2'.");
            if (answer == 1)
                IsHotWater = true;
            else if (answer == 2)
                IsHotWater = false;
            else
                return;

            Console.WriteLine(" ");

            Console.WriteLine("Имеется ли у Вас прибор учета по услуге ЭЭ?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            answer = Choose("Напишите '1' или '2'.");
            if (answer == 1)
                IsElectric = true;
            else if (answer == 2)
                IsElectric = false;
            else
                return;

            Console.WriteLine(" ");

            Console.WriteLine("Сколько людей у Вас в помещении?");

            answer = 0;
            while (answer == 0)
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    people = answer;
                }
                else
                {
                    Console.WriteLine("Напишите целое число (например, 1).");
                    answer = 0;
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine("Давайте проверим, указанные Вами данные.");

            Console.WriteLine(" ");

            Console.WriteLine("Прибор учета по услуге ХВС = " + IsColdWater);
            Console.WriteLine("Прибор учета по услуге ГВС = " + IsHotWater);
            Console.WriteLine("Прибор учета по услуге ЭЭ = " + IsElectric);
            Console.WriteLine("Количество людей в помещении: " + people);

            Console.WriteLine(" ");

            Console.WriteLine("Все верно?");
            answer = Choose("Напишите '1' или '2'.");
            if (answer == 1)
            {
                Console.WriteLine(" ");
                NextStep();
            }
            else if (answer == 2)
            {
                Console.WriteLine(" ");
                Start();
            }
            else
                return;
        }
        static void NextStep()
        {
            float answer = 0f;
            
            Console.WriteLine("Укажите текущие показания с каждого из имеющихся у Вас приборов учета.");

            Console.WriteLine(" ");

            if (IsColdWater)
            {
                Console.WriteLine("Укажите текущие показания с прибора учета по услуге ХВС.");

                while (answer == 0f)
                {
                    if (float.TryParse(Console.ReadLine(), out answer))
                    {
                        currentColdWater = answer;
                    }
                    else
                    {
                        Console.WriteLine("Напишите числовое значение, если оно дробное, пишите через запятую (например, '3,14').");
                        answer = 0f;
                    }
                }
            }

            Console.WriteLine(" ");

            answer = 0f;

            if (IsHotWater)
            {
                Console.WriteLine("Укажите текущие показания с прибора учета по услуге ГВС.");

                while (answer == 0f)
                {
                    if (float.TryParse(Console.ReadLine(), out answer))
                    {
                        currentHotWater = answer;
                    }
                    else
                    {
                        Console.WriteLine("Напишите числовое значение, если оно дробное, пишите через запятую (например, '3,14').");
                        answer = 0f;
                    }
                }
            }

            Console.WriteLine(" ");

            answer = 0f;

            if (IsElectric)
            {
                Console.WriteLine("Укажите текущие показания с прибора учета по услуге ЭЭ.");

                while (answer == 0f)
                {
                    if (float.TryParse(Console.ReadLine(), out answer))
                    {
                        currentElectric = answer;
                    }
                    else
                    {
                        Console.WriteLine("Напишите числовое значение, если оно дробное, пишите через запятую (например, '3,14').");
                        answer = 0f;
                    }
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine("Давайте проверим, указанные Вами данные.");

            Console.WriteLine(" ");

            if (IsColdWater)
                Console.WriteLine("Показания с прибора учета ХВС = " + currentColdWater);
            if (IsHotWater)
                Console.WriteLine("Показания с прибора учета ГВС = " + currentHotWater);
            if (IsElectric)
                Console.WriteLine("Показания с прибора учета ЭЭ = " + currentElectric);

            Console.WriteLine(" ");

            Console.WriteLine("Все верно?");
            answer = Choose("Напишите '1' или '2'.");
            if (answer == 1)
            {
                Console.WriteLine(" ");
                Calculate();
            }    
            else if (answer == 2)
            {
                Console.WriteLine(" ");
                NextStep();
            }
            else
                return;
        }

        static void Calculate()
        {
            if (IsColdWater)
            {

            }
            else
            {

            }

            if (IsHotWater)
            {

            }
            else
            {

            }

            if (IsElectric)
            {

            }
            else
            {

            }
        }
    }
}
