using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public struct Qcm
    {
        public string Question;
        public int Solution;
        public string[] Answers;
        public int Weight;

        public Qcm(string qst, string[] answr, int sln, int wgh) : this()
        {
            Question = qst;
            Answers = answr;
            Solution = sln;
            Weight = wgh;
        }
    }

    public class Quiz
    {
        public void AskQuestions(Qcm[] qcms)
        {
            int nombrePoints = 0;
            for (int i = 0; i < qcms.Length; i++)
            {
                Console.WriteLine(qcms[i].Question);
                foreach (string answ in qcms[i].Answers)
                {
                    Console.WriteLine(answ);
                }

                Console.WriteLine("La réponse est ? ");
                string reponse = Console.ReadLine().ToUpper();

                if (qcms[i].Answers.Contains(reponse) ) { 
                    if (string.Equals(reponse, qcms[i].Answers[qcms[i].Solution]))
                    {
                    Console.WriteLine("Bonne réponse!!!!!");
                        nombrePoints++;

                    }
                } else
                {
                    Console.WriteLine("Veuillez mettre une réponse parmi le choix proposé: ");
                    i--;

                }    

            }

            Console.WriteLine("Nombre de points : " + nombrePoints);
        }
    }
}
