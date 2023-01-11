using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("----------------------");
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();

        //Exercice I: Recherche d'un élément
            // Test exo1 search
            Search search = new Search();
                // création du tableau pour le test
                int[] tab = new int[] {1,-5,10,-3,0,4,2,-7};
                Console.WriteLine("LinearSearch");
                search.LinearSearch(tab,4);
            // dans le pire des cas, on doit lire i+1 éléments dans le tableau précédent.

            // Test exo1 dichotomique
            Console.WriteLine("BinarySearch");
            search.BinarySearch(tab, 3);
            // dans le pire des cas, on doit lire (i+1)/2 éléments dans le tableau précédent

        // Exercice II: Bases du calcul matriciel


        // Exercice IV: Questionnaire à choix multiple
        Console.WriteLine("Exercice IV: Questionnaire à choix multiple");
            // Question 1:
            string qst = "Quelle est l'anneé du sacre de Charlemagne ? ";
            string[] ans = new string[] { "476", "800", "1066", "1789" };
            int sln = 1;
            int wgh = 1;
            Qcm qcm1 = new Qcm(qst, ans,sln,wgh);

            //Question 2:
            qst = "Quelle équipe a gagné la coupde du monde en 2022 ? ";
            string[] equips = new string[] { "FRANCE", "BRESIL", "ARGENTINE", "MAROC" };
            sln = 2;
            wgh = 2;
            Qcm qcm2 = new Qcm(qst, equips, sln, wgh);

            Quiz quiz = new Quiz();
            Qcm[] qcms = new Qcm[] { qcm1, qcm2 };
            quiz.AskQuestions(qcms);
           


        }
    }
}
