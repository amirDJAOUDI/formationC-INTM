using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    class Program
    {
        static void Main(string[] args)
        {


            // Keep the console window open
            Console.WriteLine("----------------------");
            // Exercice I: Conseil de classe
            ClassCouncil conseilClasse = new ClassCouncil();
            Console.WriteLine("SchoolMeans");
            conseilClasse.SchoolMeans("Marc,Histoire,12.0,Paul,Histoire,15.5,Yvonne,Maths,6.0,David,Francais,1.2,Paul,Maths,15.5", "Histoire,Maths");
        }
    }
}
