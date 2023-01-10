using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            Console.WriteLine("hauteur: " + n);

            if (n>= 1 && n<=10)
            {

           //1) Donner le nombre de blocs pour un niveau j donné
                int nombreBlocs = 1;
                for (int i=1; i < n; i++)
                {
                    nombreBlocs = nombreBlocs + 2;
                }
                Console.WriteLine("Le nombre de bloc est de " + nombreBlocs  + " pour une hauteur de " + n);

           //2) Quel est le nombre total de blocs au niveau N
                int nombreTotalBlocs = 0;
                int nombreBlocsN = 1;
                for (int i = 1; i < 10; i++)
                {
                    nombreBlocsN = nombreBlocsN + 2;
                    nombreTotalBlocs = nombreTotalBlocs + nombreBlocsN;
                }
                Console.WriteLine("Le nombre total de bloc est de " + nombreTotalBlocs);


            }
            else
            {
                Console.WriteLine("Valeur de hauteur non comprise entre 1 et 10");
            }
        }
    }
}
