using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {


            // Keep the console window open
            Console.WriteLine("----------------------");
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();

            // Test exo1 search
                Search search = new Search();
                // création du tableau pour le test
                int[] tab = new int[] {1,-5,10,-3,0,4,2,-7};
                Console.WriteLine("LinearSearch");
                search.LinearSearch(tab,-10);
            // dans le pire des cas, on doit lire i+1 éléments dans le tableau précédent.

            // Test exo1 dichotomique
            Console.WriteLine("BinarySearch");
            search.BinarySearch(tab, 3);

        }
    }
}
