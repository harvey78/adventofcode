using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.Y_2022
{
    internal class Day_06
    {


        static public void run()
        {

            Console.WriteLine("Avvio giorno 6");

            int Marcatore1 = 0;
            int Marcatore2 = 0;
            string line = File.ReadLines("Y_2022\\input_06.txt").First();
            char[] chars = line.ToCharArray();



            for (int i = 0; i < chars.Length - 4; i++)
            {
                Marcatore1 = i + 4;

                List<char> list = new List<char>();
                for (int n = 0; n < 4; n++)
                    list.Add(chars[i + n]);
                if (list.Distinct().ToArray().Length == 4)
                    break;

            }

            for (int i = 0; i < chars.Length - 14; i++)
            {
                Marcatore2 = i + 14;

                List<char> list = new List<char>();
                for (int n = 0; n < 14; n++)
                    list.Add(chars[i + n]);
                if (list.Distinct().ToArray().Length == 14)
                    break;

            }


            Console.WriteLine("Marcatore 1  " + Marcatore1);
            Console.WriteLine("Marcatore 2  " + Marcatore2);



            Console.WriteLine("******************************************* ");

        }


    }

}

