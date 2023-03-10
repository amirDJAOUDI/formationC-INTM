using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class Morse
    {
        private const string Taah = "===";
        private const string Ti = "=";
        private const string Point = ".";
        private const string PointLetter = "...";
        private const string PointWord = ".....";

        private readonly Dictionary<string, char> _alphabet;

        public Morse()
        {
            _alphabet = new Dictionary<string, char>()
            {
                {$"{Ti}.{Taah}", 'A'},
                {$"{Taah}.{Ti}.{Ti}.{Ti}", 'B'},
                {$"{Taah}.{Ti}.{Taah}.{Ti}", 'C'},
                {$"{Taah}.{Ti}.{Ti}", 'D'},
                {$"{Ti}", 'E'},
                {$"{Ti}.{Ti}.{Taah}.{Ti}", 'F'},
                {$"{Taah}.{Taah}.{Ti}", 'G'},
                {$"{Ti}.{Ti}.{Ti}.{Ti}", 'H'},
                {$"{Ti}.{Ti}", 'I'},
                {$"{Ti}.{Taah}.{Taah}.{Taah}", 'J'},
                {$"{Taah}.{Ti}.{Taah}", 'K'},
                {$"{Ti}.{Taah}.{Ti}.{Ti}", 'L'},
                {$"{Taah}.{Taah}", 'M'},
                {$"{Taah}.{Ti}", 'N'},
                {$"{Taah}.{Taah}.{Taah}", 'O'},
                {$"{Ti}.{Taah}.{Taah}.{Ti}", 'P'},
                {$"{Taah}.{Taah}.{Ti}.{Taah}", 'Q'},
                {$"{Ti}.{Taah}.{Ti}", 'R'},
                {$"{Ti}.{Ti}.{Ti}", 'S'},
                {$"{Taah}", 'T'},
                {$"{Ti}.{Ti}.{Taah}", 'U'},
                {$"{Ti}.{Ti}.{Ti}.{Taah}", 'V'},
                {$"{Ti}.{Taah}.{Taah}", 'W'},
                {$"{Taah}.{Ti}.{Ti}.{Taah}", 'X'},
                {$"{Taah}.{Ti}.{Taah}.{Taah}", 'Y'},
                {$"{Taah}.{Taah}.{Ti}.{Ti}", 'Z'},
            };
        }

        public int LettersCount(string code)
        {

            VerifArguments(code);

            string[] listLettres = code.Split(new String[] { "..." }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("LettersCount: " + listLettres.Length);

            return listLettres.Length;
        }

        public int WordsCount(string code)
        {
            VerifArguments(code);
            string[] listWords = code.Split(new String[] { "......." }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("WordsCount: " + listWords.Length);

            return listWords.Length;
        }

        public string MorseTranslation(string code)
        {
            VerifArguments(code);

        
           string[][] traducPartiel= new string[3][];

            //List<String> traducPartiel = new List<String>();
            int j = 0;

            string[] listWords = code.Split(new String[] { "......." }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in listWords)
            {
                Console.WriteLine("word " + word);
                string[] listLettres = code.Split(new String[] { "..." }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < listLettres.Length; i++)
                {
                    Console.WriteLine(listLettres[i]);
                    // translate
                    //Char[] output = lettre.ToCharArray();
                    traducPartiel[i] = new string[i + 1];
                    string[] singleLetter = listLettres[i].Split('.');

                    foreach (string item in singleLetter)
                    {

                        if (item.Equals("="))
                        {
                            traducPartiel[i][j] = "Ti";
                            j++;

                        } else if (item.Equals("==="))
                        {
                            traducPartiel[i][j] = "Taah";
                            j++;

                        }
                    }



                }

            }




            return string.Empty;
        }

        public string EfficientMorseTranslation(string code)
        {
            //TODO
            return string.Empty;
        }

        public string MorseEncryption(string sentence)
        {
            //TODO
            return string.Empty;
        }

        void VerifArguments(string code)
        {
            // verif caractéres
            Char[] output = code.ToCharArray();

            foreach (char c in output)
            {
                if (c.Equals('.') || c.Equals('='))
                {
                    continue;
                } else
            {
                Console.WriteLine("Arguments non valides ");
                throw new ArgumentException("Au moins un argument non valide est présent!!! " + c);
            }
            }

        }
    }
}
