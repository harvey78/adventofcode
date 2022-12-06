using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Day_02
    {
        enum Simboli
        {
            Sasso, Carta, Forbici
        }

        static public void run()
        {

            Console.WriteLine("Avvio giorno 2");

            int Punteggio1 = 0;
            int Punteggio2 = 0;


            // prima colonna A come Sasso, B come Carta e C come Forbici
            // Seconda colonna X per Sasso, Y per Carta e Z per Forbici


            List<Tuple<Simboli, Simboli>> azioni1 = new();
            List<Tuple<Simboli, Simboli>> azioni2 = new();

            foreach (string line in System.IO.File.ReadLines(@"input_02.txt"))
            {
                Simboli s1;

                switch (line.Substring(0, 1))
                {
                    case "A":
                        s1 = Simboli.Sasso;
                        break;
                    case "B":
                        s1 = Simboli.Carta;
                        break;
                    case "C":
                        s1 = Simboli.Forbici;
                        break;

                    default:
                        return;
                }


                Simboli s2;

                switch (line.Substring(2, 1))
                {
                    case "X":
                        s2 = Simboli.Sasso;
                        break;
                    case "Y":
                        s2 = Simboli.Carta;
                        break;
                    case "Z":
                        s2 = Simboli.Forbici;
                        break;

                    default:
                        return;
                }

                azioni1.Add(new Tuple<Simboli, Simboli> (s1,s2));
 
            }


            Punteggio1 = getPunteggio(azioni1);

            //X significa che devi perdere, Y significa che devi concludere il round con un pareggio e Z significa che devi vincere
            foreach (string line in System.IO.File.ReadLines(@"input_02.txt"))
            {
                Simboli s1;

                switch (line.Substring(0, 1))
                {
                    case "A":
                        s1 = Simboli.Sasso;
                        break;
                    case "B":
                        s1 = Simboli.Carta;
                        break;
                    case "C":
                        s1 = Simboli.Forbici;
                        break;

                    default:
                        return;
                }


                Simboli s2;

                switch (line.Substring(2, 1))
                {
                    case "X":
                        //significa che devi perdere

                        if (s1 == Simboli.Sasso)
                            s2 = Simboli.Forbici;
                        else if (s1 == Simboli.Forbici)
                            s2 = Simboli.Carta;
                        else if(s1 == Simboli.Carta)
                            s2 = Simboli.Sasso;
                        else
                            return;

                        break;
                    case "Y":
                        //devi concludere il round con un pareggio
                        s2 = s1;
                        break;
                    case "Z":
                        //significa che devi vincere
                        if (s1 == Simboli.Sasso)
                            s2 = Simboli.Carta;
                        else if (s1 == Simboli.Forbici)
                            s2 = Simboli.Sasso;
                        else if (s1 == Simboli.Carta)
                            s2 = Simboli.Forbici;
                        else
                            return;

                        break;
                    default:
                        return;
                }

                azioni2.Add(new Tuple<Simboli, Simboli>(s1, s2));
  
            }
            Punteggio2 = getPunteggio(azioni2);


            Console.WriteLine("Punteggio parte 1 " + Punteggio1);
            Console.WriteLine("Punteggio parte 2 " + Punteggio2);

            Console.WriteLine("******************************************* ");




        }


        static private int getPunteggio(List<Tuple<Simboli, Simboli>> azioni ){
            int Punteggio = 0;

            //Calcolo vittoria
            //(0 se si è perso, 3 se si è pareggiato e 6 se si è vinto).
            foreach (var a in azioni)
            {
                if ((a.Item1 == Simboli.Sasso && a.Item2 == Simboli.Sasso) ||
                    (a.Item1 == Simboli.Carta && a.Item2 == Simboli.Carta) ||
                    (a.Item1 == Simboli.Forbici && a.Item2 == Simboli.Forbici))
                    Punteggio += 3;

                if ((a.Item1 == Simboli.Forbici && a.Item2 == Simboli.Sasso) ||
                    (a.Item1 == Simboli.Sasso && a.Item2 == Simboli.Carta) ||
                    (a.Item1 == Simboli.Carta && a.Item2 == Simboli.Forbici))
                    Punteggio += 6;

            }

            //Aggiungo simbolo vittoria
            foreach (var a in azioni)
                switch (a.Item2)
                {
                    case Simboli.Sasso:
                        Punteggio += 1;
                        break;
                    case Simboli.Carta:
                        Punteggio += 2;
                        break;
                    case Simboli.Forbici:
                        Punteggio += 3;
                        break;
                    default:
                        break;
                }

            return Punteggio;
        }
    }
}
