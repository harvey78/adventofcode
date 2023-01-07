
using System.Diagnostics;

namespace adventofcode.Y_2022;

internal class Day_09
{


    static public void run()
    {

        Console.WriteLine("Avvio giorno 9");

        List<string> lines = new();

        foreach (string line in File.ReadLines("Y_2022\\input_09.txt"))
            lines.Add(line);

        List<bool[]> LRope = new();

        for (int i = 0; i < 20; i++)
            LRope.Add(new bool[20]);

        bool[][] rope = LRope.ToArray();
        List<Tuple<int, int>> VisitList1 = new List<Tuple<int, int>>();
        List<Tuple<int, int>> VisitList2 = new List<Tuple<int, int>>();

        int[] headPos = new int[2];
        int[] tailPos = new int[2];

        
        List<side> Directions = new();
        foreach (var l in lines)
        {
            string s = l.Substring(0, 1);
            int num = int.Parse(l.Substring(2));
            side side= side.left;
            if (s == "R")
                side = side.right;
            else if (s == "L")
                side = side.left;
            else if (s == "U")
                side = side.up;
            else if (s == "D")
                side = side.down;
            else
                Debugger.Break();

            for (int i = 0; i < num; i++)
                Directions.Add(side);
        }


        foreach (var d in Directions)
        {
            //Sposto la testa
            if (d == side.up)
                headPos[0]++;
            else if (d == side.down)
                headPos[0]--;
            else if (d == side.left)
                headPos[1]--;
            else if (d == side.right)
                headPos[1]++;

            moveRope(headPos, tailPos);      

            //Smarco la posizione
            Tuple<int, int> newTuple = new Tuple<int, int>(tailPos[0], tailPos[1]);
            if (!VisitList1.Contains(newTuple))
                VisitList1.Add(newTuple);
        }


        headPos = new int[2];
        List<int[]> tP = new();
        for (int i = 0; i < 9; i++)
            tP.Add(new int[2]);
        int[][] tPos = tP.ToArray();
        int numero = 0;
        foreach (var d in Directions)
        {
            //Sposto la testa
            if (d == side.up)
                headPos[0]++;
            else if (d == side.down)
                headPos[0]--;
            else if (d == side.left)
                headPos[1]--;
            else if (d == side.right)
                headPos[1]++;
            numero++;
            moveRope(headPos, tPos[0]);



            for (int i = 0; i < 9 - 1; i++)    
                moveRope(tPos[i], tPos[i + 1]);             

            //Smarco la posizione
            Tuple<int, int> newTuple = new Tuple<int, int>(tPos[8][0], tPos[8][1]);
            if (!VisitList2.Contains(newTuple))
                VisitList2.Add(newTuple);

        }



        Console.WriteLine("Numero visite 1        " + VisitList1.Count);
        Console.WriteLine("Numero visite 2        " + VisitList2.Count);


        Console.WriteLine("******************************************* ");

    }


    static void moveRope(int[] headPos, int[] tailPos)
    {
        //Sposto la coda  
        int deltaR = headPos[0] - tailPos[0];
        int deltaC = headPos[1] - tailPos[1];

        if (deltaR >= -1 && deltaR <= 1 && deltaC >= -1 && deltaC <= 1)
        {
            //Passo
        }
        else
        {
            if (deltaR == 2)
            {
                if (deltaC >= 1)
                {
                    tailPos[0]++;
                    tailPos[1]++;
                }
                else if (deltaC == 0)
                    tailPos[0]++;
                else if (deltaC <= -1)
                {
                    tailPos[0]++;
                    tailPos[1]--;
                }
                else
                    Debugger.Break();
            }
            else if (deltaR == -2)
            {
                if (deltaC >= 1)
                {
                    tailPos[0]--;
                    tailPos[1]++;
                }
                else if (deltaC == 0)
                    tailPos[0]--;
                else if (deltaC <= -1)
                {
                    tailPos[0]--;
                    tailPos[1]--;
                }
                else
                    Debugger.Break();
            }
            else if (deltaC == 2)
            {
                if (deltaR >= 1)
                {
                    tailPos[0]++;
                    tailPos[1]++;
                }
                else if (deltaR == 0)
                    tailPos[1]++;
                else if (deltaR <= -1)
                {
                    tailPos[0]--;
                    tailPos[1]++;
                }
                else
                    Debugger.Break();
            }
            else if (deltaC == -2)
            {
                if (deltaR >= 1)
                {
                    tailPos[0]++;
                    tailPos[1]--;
                }
                else if (deltaR == 0)
                    tailPos[1]--;
                else if (deltaR <= -1)
                {
                    tailPos[0]--;
                    tailPos[1]--;
                }
                else
                    Debugger.Break();
            }
            else
                Debugger.Break();
        }

         //deltaR = headPos[0] - tailPos[0];
         //deltaC = headPos[1] - tailPos[1];

        //if (deltaR == -2 || deltaR == 2 || deltaC == -2 || deltaC == 2)
        //{ }

    }

    enum side
    {
        right, left,
        up, down,
    }

}

