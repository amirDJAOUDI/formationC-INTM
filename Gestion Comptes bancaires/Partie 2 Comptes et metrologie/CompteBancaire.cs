using Parse_csv;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CompteBancaire
{
    class Compte
    {

        public Compte()
        {
 
        }
        public void OperationComptes(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.transactionGestionnaires[] transactionGestionnaires)
        {
            try
            {
                // tableau des comptes créés
                Parse_csv.operationsComptes[] operationsCreationCompte = new Parse_csv.operationsComptes[operationsComptes.Length];
                int K =0;

                // tableau des comptes cloturés
                Parse_csv.operationsComptes[] operationsClotureCompte = new Parse_csv.operationsComptes[operationsComptes.Length];
                int j = 0;

                // indice des échanges de comptes réussis
                int n = 0;
                // nombre total de transaction
                int i = 0;

                // définir le type d'opération des comptes
                for (i = 0; i< operationsComptes.Length; i++)
                {

                    if(!operationsComptes[i].entree.Equals("") && !operationsComptes[i].sortie.Equals(""))
                    {
                       // opération d'échange de compte
                       n = OperationEchange(operationsComptes, operationsCreationCompte, operationsClotureCompte, i, K, j, n, transactionGestionnaires);   

                    } else
                    {
                        // oprétaion de création de compte
                        if (!operationsComptes[i].entree.Equals("") && !operationsComptes[i].date.Equals(""))
                        {
                            Console.WriteLine("Création du compte: " + operationsComptes[i].compteId);
                            operationsCreationCompte[K] = operationsComptes[K];
                            K++;
                        }

                        // oprétaion de cloture de compte
                        if (!operationsComptes[i].sortie.Equals(""))
                        {
                            
                            for (int l = 0; l < K; l++)
                            {
                                if (operationsCreationCompte[l].compteId.Equals(operationsComptes[i].compteId) && 
                                   (Convert.ToDateTime(operationsCreationCompte[l].date) < Convert.ToDateTime(operationsComptes[i].date)))
                                {
                                    Console.WriteLine("Cloture du compte: " + operationsComptes[i].compteId);
                                    operationsClotureCompte[j] = operationsComptes[j];
                                    j++;

                                }
                            }

                            
                        }
                    }
                }

                Console.WriteLine("nombre de creations reussis (=nombre de comptes): " + K);
                Console.WriteLine("nombre d'échange reussis                        : " + n);
                Console.WriteLine("nombre de clotures reussis                      : " + j);
                Console.WriteLine("nombre total de transactions réussis            : " + (j+K+n));
                Console.WriteLine("nombre total de transactions en échecs          : " + (i-(j + K + n)));
                Console.WriteLine("nombre total de transactions                    : " + i);

            }

            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

        }


        private int OperationEchange(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.operationsComptes[] operationsCreationCompte, 
                                     Parse_csv.operationsComptes[] operationsClotureCompte,int i, int k, int j, int n, Parse_csv.transactionGestionnaires[] transactionGestionnaires)
        {
            for (int l = 0; l < k; l++)
            {

                if (operationsCreationCompte[l].compteId.Equals(operationsComptes[i].compteId) 
                    && ((Convert.ToDateTime(operationsCreationCompte[l].date) < Convert.ToDateTime(operationsComptes[i].date)))
                    && (operationsCreationCompte[l].entree.Equals(operationsComptes[i].entree)))
                {

                    for (int o = 0; o < transactionGestionnaires.Length; o++)
                    {

                        if (Convert.ToString(transactionGestionnaires[o].gestionnaireid).Equals(operationsComptes[i].sortie))
                        {

                            if (j == 0)
                            {
                                Console.WriteLine("Échange du compte: " + operationsComptes[i].compteId);
                                n++;
                            }
                            else
                            {

                                for (int m = 0; m < j; m++)
                                {

                                    if (operationsClotureCompte[m].compteId.Equals(operationsComptes[i].compteId))
                                    {
                                        Console.WriteLine("Le compte est cloturé: " + operationsComptes[i].compteId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Échange du compte: " + operationsComptes[i].compteId);
                                        n++;
                                    }
                                }


                            }

                        }
                    }

                   

                }
            }

            return n;
        }

    }
}