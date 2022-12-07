using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.Y_2022
{
    internal class Day_01
    {
        static public void run()
        {

            Console.WriteLine("Avvio giorno 1");

            int counter1 = 0;

            int actualElf = 0;


            List<int> calories = new List<int>();
            foreach (string line in File.ReadLines(@"Y_2022\input_01.txt"))
            {
                if (line.Trim() == "")
                {
                    calories.Add(actualElf);
                    actualElf = 0;
                }
                else
                {
                    actualElf += int.Parse(line.Trim());
                }

                counter1++;
            }

            //foreach (var c in calories)
            //{
            //    System.Console.WriteLine(c);
            //    counter2++;
            //}



            //Console.WriteLine("Righe "+ counter1);
            //Console.WriteLine("Elfi " + counter2);
            Console.WriteLine("Calorie del carico maggiore " + calories.Max());
            int[] OrderCalories = calories.Order().ToArray();
            int Max3 = OrderCalories[OrderCalories.Length - 1] + OrderCalories[OrderCalories.Length - 2] + OrderCalories[OrderCalories.Length - 3];
            Console.WriteLine("Calorie dei 3 carichi maggiori " + Max3);
            Console.WriteLine("******************************************* ");

        }
    }
}
