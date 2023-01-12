using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {


            // Keep the console window open
            Console.WriteLine("----------------------");
            // Exercice I: Code Morse
            Console.WriteLine("Exercice I: Code Morse");
            Morse codeMorse = new Morse();
            // exemple AZUL en morse
            codeMorse.LettersCount("=.===...===.===.=.=...=.=.===...=.===.=.=");
            // exemple AZUL AMIR en morse
            codeMorse.WordsCount("=.===...===.===.=.=...=.=.===...=.===.=.=.......=.===...===.===...=.=...=.===.=");
        }
    }
}
