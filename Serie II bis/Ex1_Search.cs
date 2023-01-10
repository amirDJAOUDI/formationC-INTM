using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public class Search
    {
        public int LinearSearch(int[] tableau, int valeur)
        {
            int indice = -1;

            for (int i = 0; i < tableau.Length; i++)
            {

                if (valeur == tableau[i])
                {
                    indice = i;
                };
            }

            Console.WriteLine("indice: " + indice);

            return indice;
        }

        public int BinarySearch(int[] tableau, int valeur)
        {
           Array.Sort(tableau);
           int g = 0;
           int d = tableau.Length - 1;
           int i = 0;


       while (i <= d )
            {
                i = (g + d) / 2;
                if (tableau[i] < valeur)
                    g = i + 1;
                else
                    d = i - 1;
            }

            Console.WriteLine("indice: " + i);

            return i;
        }
    }
}
