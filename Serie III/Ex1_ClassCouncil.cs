using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{ 

    public class ClassCouncil
    {

        double moyenneFrancais = 0;
        double moyenneMaths = 0;
        double moyenneHistoire = 0;
        public void SchoolMeans(string input, string output)



        {
            string[] listNotesParNomEtMatiere = input.Split(',');
            
            Boolean premierPassageFrancais = false;
            Boolean premierPassageMaths = false;
            Boolean premierPassageHistoire = false;

            for (int i =0; i < listNotesParNomEtMatiere.Length;i++)
            {

                switch (listNotesParNomEtMatiere[i])
                {

                    case "Francais":

                        if (premierPassageFrancais)
                                {
                            moyenneFrancais = CalcMoyenne(moyenneFrancais, listNotesParNomEtMatiere[i + 1]);

                        } else
                        {
                            moyenneFrancais = Convert.ToDouble(listNotesParNomEtMatiere[i + 1], new CultureInfo("en-US"));
                            premierPassageFrancais = true;
                        }

                        break;

                    case "Maths":

                        if (premierPassageMaths)
                            {
                            moyenneMaths = CalcMoyenne(moyenneMaths, listNotesParNomEtMatiere[i + 1]);

                        }
                        else
                        {
                            moyenneMaths = Convert.ToDouble(listNotesParNomEtMatiere[i + 1], new CultureInfo("en-US"));
                            premierPassageMaths = true;
                        }

                        break;

                    case "Histoire":

                        if (premierPassageHistoire)
                        {
                            moyenneHistoire = CalcMoyenne(moyenneHistoire, listNotesParNomEtMatiere[i + 1]);
                        }
                        else
                        {
                            moyenneHistoire = Convert.ToDouble(listNotesParNomEtMatiere[i + 1], new CultureInfo("en-US"));
                            premierPassageHistoire = true;
                        }
                        break;



                }

            }

            // Display moyennes par matiere

            Display(output);




        }
     double CalcMoyenne(double savMoyenne, string noteMatiere)
        {
            double moyennes = (savMoyenne + Convert.ToDouble(noteMatiere, new CultureInfo("en-US"))) / 2;

            return moyennes;
        }


         void Display(string matieres)
        {
            string[] listMatieres = matieres.Split(',');

            for (int i = 0; i < listMatieres.Length; i++)
            {

                switch (listMatieres[i])
                {
                    case "Francais":
                        Console.WriteLine("La moyenne de Francais: " + moyenneFrancais);
                        break;

                    case "Maths":
                        Console.WriteLine("La moyenne de Maths: " + moyenneMaths);
                        break;

                    case "Histoire":
                        Console.WriteLine("La moyenne d'Histoire: " + moyenneHistoire);
                        break;

                }
    }
        }
    }
}
