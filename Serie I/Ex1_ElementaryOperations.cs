using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {

            // Créer une liste 
            List<string> vListValideOperateurs = new List<string>();
            // Ajouter des éléments à la liste 
            vListValideOperateurs.Add("+");
            vListValideOperateurs.Add("-");
            vListValideOperateurs.Add("*");
            vListValideOperateurs.Add("/");

            if (vListValideOperateurs.Contains(getString(operation)) == false || (a==0 || b==0))
            {
                Console.WriteLine("Opération invalide");
            } else
            {
                Console.WriteLine(a + operation + b);
            }
        }

        private static string getString(char operation)
        {
            throw new NotImplementedException();
        }

        public static void IntegerDivision(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Opération invalide");
            }
            else
            {
                long reste;
                long quotient = Math.DivRem(a, b, out reste);
                Console.WriteLine( a = (int)(quotient * b + reste));
            }
        }

        public static void Pow(int a, int b)
        {
            //TODO
        }
    }
}
