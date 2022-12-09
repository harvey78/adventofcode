using System.Collections.Generic;

namespace adventofcode.Y_2022;

internal class Day_08
{


    static public void run()
    {

        Console.WriteLine("Avvio giorno 8");

        List<string> lines = new();

        foreach (string line in File.ReadLines("Y_2022\\input_08.txt"))
            lines.Add(line);

        List<int[]> blist = new List<int[]>();

        foreach (var l in lines)
        {
            List<int> list = new List<int>();
            char[] chars = l.ToCharArray();
            foreach (var c in chars)
                list.Add(c - 48);

            blist.Add(list.ToArray());
        }
        int[][] Bosco = blist.ToArray();

        int Trees = 0;
        int PanoramaMassimo = 0;
        int Panorama = 0;

        for (int r = 0; r < Bosco.Length; r++)
        {
            for (int c = 0; c < Bosco[r].Length; c++)
            {
                if (SeVisto(Bosco, r, c))
                {
                    Trees++;
                    //Console.ForegroundColor = ConsoleColor.Green;
                }
                //else
                    //Console.ForegroundColor = ConsoleColor.Red;
                //Console.Write(Bosco[r][c]);
            }
            //Console.WriteLine("");
        }
        //Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("******************************************* ");

        for (int r = 0; r < Bosco.Length; r++)
        {
            for (int c = 0; c < Bosco[r].Length; c++)
            {
                Panorama = CalcolaPanorama(Bosco, r, c);
                //Console.Write(Panorama.ToString("00 "));
                if (Panorama > PanoramaMassimo)
                    PanoramaMassimo = Panorama;

            }
            //Console.WriteLine("");
        }


        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("alberi visibili         " + Trees);
        Console.WriteLine("Panorama massimo        " + PanoramaMassimo);


        Console.WriteLine("******************************************* ");

    }

    static private bool SeVisto(int[][] Bosco, int r, int c)
    {
        //if (c == 0 || r == 0 || c == Bosco.Length - 1 || r == Bosco[c].Length - 1)
        if (r == 0)
            return true;

        int Altezza = Bosco[r][c];

        bool rTop = true;
        bool rLeft = true;
        bool fBottom = true;
        bool fRight = true;

        for (int i = 0; i < r; i++)
            if (Bosco[i][c] >= Altezza)
                rTop = false;

        for (int i = 0; i < c; i++)
            if (Bosco[r][i] >= Altezza)
                rLeft = false;

        for (int i = Bosco.Length - 1; i > r; i--)
            if (Altezza <= Bosco[i][c])
                fBottom = false;

        for (int i = Bosco[r].Length - 1; i > c; i--)
            if (Altezza <= Bosco[r][i])
                fRight = false;


        return rTop || rLeft || fBottom || fRight;
    }
    static private int CalcolaPanorama(int[][] Bosco, int r, int c)
    {
        int Altezza = Bosco[r][c];

        int pTop = 0;
        int pLeft = 0;
        int pBottom = 0;
        int pRight = 0;

        for (int i = r + 1; i < Bosco.Length; i++)
            if (Bosco[i][c] < Altezza)
                pBottom++;
            else
            {
                pBottom++;
                break;
            }


        for (int i = r - 1; i >= 0; i--)
            if (Bosco[i][c] < Altezza)
                pTop++;
            else
            {
                pTop++;
                break;
            }


        for (int i = c + 1; i < Bosco[r].Length; i++)
            if (Bosco[r][i] < Altezza)
                pRight++;
            else
            {
                pRight++;
                break;
            }

        for (int i = c - 1; i >= 0; i--)
            if (Bosco[r][i] < Altezza)
                pLeft++;
            else
            {
                pLeft++;
                break;
            }


        return pTop * pLeft * pBottom * pRight;
    }

}

