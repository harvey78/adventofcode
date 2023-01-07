
using Microsoft.Win32;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace adventofcode.Y_2022;

internal class Day_11
{


    static public void run()
    {

        Console.WriteLine("Avvio giorno 11");


        List<string> lines = new();

        foreach (string line in File.ReadLines("Y_2022\\input_11.txt"))
            lines.Add(line);
        int pos = 0;

        List<Monkey> Monkeys = new List<Monkey>();
        do
        {
            List<string> l = new();
            for (int i = 0; i < 7; i++)
            {
                l.Add(lines[pos]);
                pos++;
            }
            Monkeys.Add(new Monkey(l.ToArray()));
        } while (lines.Count > pos);


        for (int i = 0; i < 20; i++)
            foreach (var Monkey in Monkeys)
                while (Monkey.StartingItems.Count > 0)
                {
                    Monkey.inspected++;
                    var WorryLevel = Monkey.StartingItems[0];
                    Monkey.StartingItems.RemoveAt(0);

                    if (Monkey.OpType == Monkey.enumType.Add)
                        WorryLevel = WorryLevel + Monkey.OpVal;
                    else if (Monkey.OpType == Monkey.enumType.Mult)
                        WorryLevel = WorryLevel * Monkey.OpVal;
                    else if (Monkey.OpType == Monkey.enumType.Exp)
                        WorryLevel = WorryLevel * WorryLevel;

                    WorryLevel = WorryLevel / 3;


                    if (WorryLevel % Monkey.TestDiv == 0)
                        Monkeys[Monkey.IfTrue].StartingItems.Add(WorryLevel);
                    else
                        Monkeys[Monkey.IfFalse].StartingItems.Add(WorryLevel);

                }


        List<long> inspected = new();
        foreach (var Monkey in Monkeys)
            inspected.Add(Monkey.inspected);

        inspected = inspected.OrderBy(i => i).Reverse().ToList();


        Console.WriteLine("Monkey Business 1       " + inspected[0] * inspected[1]);



        Monkeys.Clear();
        pos = 0;
        do
        {
            List<string> l = new();
            for (int i = 0; i < 7; i++)
            {
                l.Add(lines[pos]);
                pos++;
            }
            Monkeys.Add(new Monkey(l.ToArray()));
        } while (lines.Count > pos);



        long factor = Monkeys.Select(m => m.TestDiv).Aggregate((f1, f2) => f1 * f2);


        for (int i = 0; i < 10000; i++)
            foreach (var Monkey in Monkeys)
                while (Monkey.StartingItems.Count > 0)
                {
                    Monkey.inspected++;
                    var WorryLevel = Monkey.StartingItems[0];
                    Monkey.StartingItems.RemoveAt(0);

                    if (Monkey.OpType == Monkey.enumType.Add)
                        WorryLevel = WorryLevel + Monkey.OpVal;
                    else if (Monkey.OpType == Monkey.enumType.Mult)
                        WorryLevel = WorryLevel * Monkey.OpVal;
                    else if (Monkey.OpType == Monkey.enumType.Exp)
                        WorryLevel = WorryLevel * WorryLevel;

                    WorryLevel = WorryLevel % factor;


                    if (WorryLevel % Monkey.TestDiv == 0)
                        Monkeys[Monkey.IfTrue].StartingItems.Add(WorryLevel);
                    else
                        Monkeys[Monkey.IfFalse].StartingItems.Add(WorryLevel);

                }

        inspected.Clear();
        foreach (var Monkey in Monkeys)
            inspected.Add(Monkey.inspected);

        inspected = inspected.OrderBy(i => i).Reverse().ToList();


        Console.WriteLine("Monkey Business 2       " + inspected[0] * inspected[1]);


        Console.WriteLine("******************************************* ");

    }

    class Monkey
    {
        //      Monkey 0:
        //Starting items: 79, 98
        //Operation: new = old* 19
        //Test: divisible by 23
        //  If true: throw to monkey 2
        //  If false: throw to monkey 3

        public long MonkeyPos;
        public List<long> StartingItems = new();
        public enumType OpType;
        public long OpVal;
        public long TestDiv;
        public int IfTrue;
        public int IfFalse;
        public long inspected;

        public enum enumType { none, Add, Mult, Exp }

        public Monkey(string[] lines)
        {
            string tmp = lines[0].Trim();
            tmp = tmp.Substring(0, tmp.Length - 1);
            tmp = tmp.Substring(tmp.IndexOf(" ") + 1);

            MonkeyPos = int.Parse(tmp);

            tmp = lines[1].Trim();
            tmp = tmp.Substring(tmp.IndexOf(":") + 1);

            foreach (var i in tmp.Split(","))
                StartingItems.Add(long.Parse(i));


            tmp = lines[2].Trim();
            tmp = tmp.Substring(tmp.IndexOf("=") + 1).Trim();
            var spl = tmp.Split(" ");
            if (spl[1] == "*")
                OpType = enumType.Mult;
            if (spl[1] == "+")
                OpType = enumType.Add;
            if (spl[2] == "old")
                OpType = enumType.Exp;
            else
                OpVal = long.Parse(spl[2]);

            tmp = lines[3].Trim();
            tmp = tmp.Substring(tmp.IndexOf(":") + 1).Trim();
            TestDiv = long.Parse(tmp.Substring(13));

            IfTrue = int.Parse(lines[4].Trim().Substring(25));
            IfFalse = int.Parse(lines[5].Trim().Substring(26));


        }

    }

    static private int MassimoComunDivisore(int a, int b)
    {
        int resto;
        while (b != 0)
        {
            resto = a % b;
            a = b;
            b = resto;
        }
        return a;
    }

}

