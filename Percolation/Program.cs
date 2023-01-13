using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            // 3.a)
            //ouverture aleatoire d'une position i et j: utilisation de la méthode random et 36 correspond à la taille du tableau

            Random rnd = new Random();
            Percolation Perco = new Percolation();

            for (int i = 0;i < 36 ; i++) { 
            
            Perco.Open(36 * rnd.Next(), 36 * rnd.Next());

            }


            // 3.b)
            /* dans le pire des cas, on doit ouvertir (_size - i) + 1 cases pour avoir percolation.
            Exemple pour un tableau de 6 * 6 ==> 36 - 6 + 1, donc 31 ouverture de case max pour avoir percolation. */

            // 3.c) la probablité statistique pour que ce cas se produit est infine car on utilise un random qui génére un nombre de facon aléatoire et la probablité d'ouvrir toutes les cases à l'exception du dernier est trés basse.
        }
    }
}
