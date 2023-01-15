using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {

        // 3.b)
        /* dans le pire des cas, on doit ouvertir (_size - i) + 1 cases pour avoir percolation.
        Exemple pour un tableau de 6 * 6 ==> 36 - 6 + 1, donc 31 ouverture de case max pour avoir percolation. */

        // 3.c) la probablité statistique pour que ce cas se produit est infine car on utilise un random qui génére un nombre de facon aléatoire
        //      et la probablité d'ouvrir toutes les cases à l'exception du dernier étage est trés basse.



        static void Main(string[] args)
        {


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Percolation");

            // 3.a)
            //ouverture aleatoire d'une position i et j: utilisation de la méthode random et la taille du tableau est de (6x6)
                /*Random rnd = new Random();
            Percolation Perco = new Percolation(6);
            Perco.Open(rnd.Next(0,6), rnd.Next(0, 6)); */


            // simulation
            PercolationSimulation PercoSimul = new PercolationSimulation();
             //PercoSimul.PercolationSimul();

            PercoSimul.MeanPercolationValue(80, 75);


        }
    }
}
