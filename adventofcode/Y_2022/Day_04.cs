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
    internal class Day_04
    {


        static public void run()
        {

            Console.WriteLine("Avvio giorno 4");

            int Punteggio1 = 0;
            int Punteggio2 = 0;

            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines("Y_2022\\input_04.txt"))
                lines.Add(line);

            //**********************************
            foreach (string line in lines)
            {
                string[] part1 = line.Split(',');
                string[] partA = part1[0].Split('-');
                string[] partB = part1[1].Split('-');

                int Min1 = int.Parse(partA[0]);
                int Max1 = int.Parse(partA[1]);
                int Min2 = int.Parse(partB[0]);
                int Max2 = int.Parse(partB[1]);

                if (Min1 >= Min2 && Max1 <= Max2 ||
                     Min1 <= Min2 && Max1 >= Max2)
                {
                    Punteggio1++;
                    Punteggio2++;
                }
                else if (Min1 >= Min2 && Min1 <= Max2 ||
                    Max1 >= Min2 && Max1 <= Max2)
                    Punteggio2++;

            }






            //573
            Console.WriteLine("Incarichi Uguali " + Punteggio1);
            //
            Console.WriteLine("Incarichi Sovrapposti " + Punteggio2);

            Console.WriteLine("******************************************* ");

        }


    }

}

