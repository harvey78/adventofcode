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
    internal class Day_03
    {


        static public void run()
        {

            Console.WriteLine("Avvio giorno 3");

            int Punteggio1 = 0;
            int Punteggio2 = 0;

            List<char> charList = new List<char>();
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines(@"Y_2022\input_03.txt"))
                lines.Add(line);

            //**********************************
            foreach (string line in lines)
            {
                string part1 = line.Substring(0, line.Length / 2);
                string part2 = line.Substring(line.Length / 2);
                char[] charts1 = part1.ToCharArray();
                char[] charts2 = part2.ToCharArray();

                char[] charts3 = equalChar(charts1, charts2);
                charList.AddRange(charts3);
            }

            foreach (var c in charList)
            {
                if (c >= 'a' && c <= 'z')
                    Punteggio1 += c - 'a' + 1;

                else if (c >= 'A' && c <= 'Z')
                    Punteggio1 += c - 'A' + 27;
                else
                { }
            }


            //**********************************
            charList.Clear();
            for (int i = 0; i < lines.Count / 3; i++)
            {
                char[] charts1 = lines[i * 3].ToCharArray();
                char[] charts2 = lines[i * 3 + 1].ToCharArray();
                char[] charts3 = lines[i * 3 + 2].ToCharArray();
                char[] charts4 = equalChar(charts1, charts2);
                char[] charts5 = equalChar(charts3, charts4);
                charList.AddRange(charts5);

            }


            foreach (var c in charList)
            {
                if (c >= 'a' && c <= 'z')
                    Punteggio2 += c - 'a' + 1;

                else if (c >= 'A' && c <= 'Z')
                    Punteggio2 += c - 'A' + 27;
                else
                { }
            }

            Console.WriteLine("Punteggio parte 1 " + Punteggio1);
            Console.WriteLine("Punteggio parte 2 " + Punteggio2);

            Console.WriteLine("******************************************* ");

        }


        static char[] equalChar(char[] c1, char[] c2)
        {
            List<char> equal = new List<char>();

            foreach (var c in c1)
                if (c2.Contains(c) && !equal.Contains(c))
                    equal.Add(c);

            return equal.ToArray();

        }

    }
}
