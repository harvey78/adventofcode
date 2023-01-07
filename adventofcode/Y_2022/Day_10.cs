
using Microsoft.Win32;
using System.Diagnostics;

namespace adventofcode.Y_2022;

internal class Day_10
{


    static public void run()
    {

        Console.WriteLine("Avvio giorno 10");


        int register = 1;
        List<int> registers = new List<int>();
        List<string> lines = new();

        foreach (string line in File.ReadLines("Y_2022\\input_10.txt"))
            lines.Add(line);


        registers.Add(register);

        foreach (string l in lines)
        {

            if (l == "noop")
                registers.Add(register);
            else if (l.StartsWith("addx"))
            {
                int n = int.Parse(l.Substring(5));
                registers.Add(register);
                register = register + n;
                registers.Add(register);

            }
            else
                Debugger.Break();
        }

        int[] r = registers.ToArray();

        int signal1 = r[19] * 20 + r[59] * 60 + r[99] * 100 + r[139] * 140 + r[178] * 180 + r[219] * 220;
        Console.WriteLine("signal strengths 1        " + signal1);

        int pos = 0;
        for (int i = 0; i < 240; i++)
        {
            int delta =Math.Abs( r[i]- pos);

            if(delta <=1)
                Console.Write("#");
            else
                Console.Write(".");

            pos++;
            if (pos==40)
            {
                Console.WriteLine("");
                pos = 0;
            }
        }


        Console.WriteLine("******************************************* ");

    }

    

}

