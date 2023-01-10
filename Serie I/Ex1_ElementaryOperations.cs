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
    public class ElementaryOperations
    {
        public void BasicOperation(int a, int b, char operation)
        {

            // Créer une liste et ajouter les éléments de la liste
            List<char> vListValideOperateurs = new List<char> { '+','-','*','/'};
           
            // verifications 1) l'opérateur est bien dans la liste, 2) b n'est pas égal à zéro 
            if (vListValideOperateurs.Contains(operation) == false || b==0)
            {
                Console.WriteLine("Opération invalide");
            } else
            {

                int result =0;
                if (operation == '+')
                    result = a + b;
                else if (operation == '-')
                    result = a - b;
                else if (operation == '*')
                    result = a * b;
                else if (operation == '/')
                    result = a / b;

                Console.WriteLine(result);
            }
        }

        public void IntegerDivision(int a, int b)
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

        public void Pow(int a, int b)
        {
            if (b == 0)
            {Console.WriteLine("Opération invalide");}
            else{

                Console.WriteLine(Math.Pow(a, b));

            }
            }
    }
}
