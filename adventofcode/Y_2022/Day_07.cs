using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventofcode.Y_2022
{
    internal class Day_07
    {


        static public void run()
        {

            Console.WriteLine("Avvio giorno 7");

            int Marcatore1 = 0;
            int Marcatore2 = 0;
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines("Y_2022\\input_07.txt"))
                lines.Add(line);


            //  cd significa cambiare directory. Cambia la directory corrente, ma il risultato specifico dipende dall'argomento:
            //  cd x si sposta di un livello: cerca nella directory corrente la directory denominata x e la rende la directory corrente.
            //  cd..si sposta di un livello: trova la directory che contiene la directory corrente e la rende tale.
            //  cd / cambia la directory corrente in quella più esterna, /.
            //  ls significa elenco.Stampa tutti i file e le directory immediatamente contenuti nella directory corrente:
            //  123 abc significa che la directory corrente contiene un file di nome abc di dimensioni 123.
            //  dir xyz significa che la directory corrente contiene una directory di nome xyz.
            //  Dati i comandi e l'output dell'esempio precedente, è possibile determinare che il filesystem


            foreach (var l in lines)
                if (l.StartsWith('$'))
                {

                }
                else
                {

                }




            Console.WriteLine("Marcatore 1  " + Marcatore1);
            Console.WriteLine("Marcatore 2  " + Marcatore2);



            Console.WriteLine("******************************************* ");

        }


    }

}

