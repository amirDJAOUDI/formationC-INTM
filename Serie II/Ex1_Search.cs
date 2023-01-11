using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {

            int indice = -1;
            valeur = 2;
            tableau = new int[] { 1, -5, 10, -3, 0, 4, 2, -7 };

            Console.WriteLine(valeur);


            for (int i = 0; i < tableau.Length; i++)
            {

                Console.WriteLine(tableau[i]);
                Console.WriteLine("i: " + i);

                if (valeur == tableau[i])
                {
                    indice = i;
                };
            }

            Console.WriteLine("indice: " + indice);

            return indice;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            //TODO
            return -1;
        }
    }
}
