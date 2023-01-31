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

        static int people = 1;

        static int answer;

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Расчет оплаты ЖКХ");
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

            Console.WriteLine(people);
            Console.ReadLine();
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
    }
}
