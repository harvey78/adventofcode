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
    internal class Day_05
    {


        static public void run()
        {

            Console.WriteLine("Avvio giorno 5");


            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines("Y_2022\\input_05.txt"))
                lines.Add(line);

            List<Stack<char>> stacks1 = new();
            List<Stack<char>> stacks2 = new();

            //Riepo la parte iniziale
            for (int c = 0; c < 9; c++)
            {
                Stack<char> stack1 = new();
                Stack<char> stack2 = new();
                for (int r = 0; r < 8; r++)
                {
                    string str = lines[7 - r].Substring(1 + 4 * c, 1);
                    if (str != " ")
                    {
                        stack1.Push(str[0]);
                        stack2.Push(str[0]);
                    }
                }
                stacks1.Add(stack1);
                stacks2.Add(stack2);
            }

            lines.RemoveRange(0, 10);
            //**********************************
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');


                int Num = int.Parse(parts[1]);
                int PosForm = int.Parse(parts[3]);
                int PosTo = int.Parse(parts[5]);

                for (int i = 0; i < Num; i++)
                {
                    char c = stacks1[PosForm - 1].Pop();
                    stacks1[PosTo - 1].Push(c);
                }


                Stack<char> stackTemp = new();

                for (int i = 0; i < Num; i++)
                    stackTemp.Push(stacks2[PosForm - 1].Pop());

                for (int i = 0; i < Num; i++)
                    stacks2[PosTo - 1].Push(stackTemp.Pop());


            }


            string Top = "";
            foreach (var s in stacks1)
                Top = Top + s.Peek();


            Console.WriteLine("Casse sopra con CrateMover 9000  " + Top);

            Top = "";
            foreach (var s in stacks2)
                Top = Top + s.Peek();
            Console.WriteLine("Casse sopra con CrateMover 9001  " + Top);


            Console.WriteLine("******************************************* ");

        }


    }

}

