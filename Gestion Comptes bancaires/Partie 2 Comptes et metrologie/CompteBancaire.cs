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
        int montantTotalReussites = 0;
        int n = 0;

        public Compte()
        {
 
        }
        public void OperationComptes(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.transactionGestionnaires[] transactionGestionnaires, Parse_csv.transactions[] transactions)
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
                Parse_csv.operationsComptes[] operationsEchangeCompte = new Parse_csv.operationsComptes[operationsComptes.Length];

                // nombre total de transaction
                int i = 0;

                // définir le type d'opération des comptes
                for (i = 0; i< operationsComptes.Length; i++)
                {

                    if(!operationsComptes[i].entree.Equals("") && !operationsComptes[i].sortie.Equals(""))
                    {
                        // opération d'échange de compte
                        operationsEchangeCompte = OperationEchange(operationsComptes, operationsCreationCompte, operationsClotureCompte, i, K, j, transactionGestionnaires);   

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


                Parse_csv.metrologie metrologie = new Parse_csv.metrologie();

                Console.WriteLine("nombre d'échange de comptes reussis    : " + n);
                Console.WriteLine("nombre de clotures reussis             : " + j);
                Console.WriteLine("nombre de comptes créés                : " + K);

                Console.WriteLine("*******Fichier des transactions**************");
                metrologie.statistique = "Statistiques :";
                Console.WriteLine(metrologie.statistique);

                metrologie.nombreComptes = $"Nombre de comptes : {K}";
                Console.WriteLine(metrologie.nombreComptes);
                

                OperationTransaction(operationsComptes, transactions, operationsCreationCompte, operationsClotureCompte, operationsEchangeCompte, metrologie) ;

            }

            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

        }

        public void OperationTransaction(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.transactions[] transactions, 
                                         Parse_csv.operationsComptes[] operationsCreationCompte, Parse_csv.operationsComptes[] operationsClotureCompte,
                                         Parse_csv.operationsComptes[] operationsEchangeCompte, Parse_csv.metrologie metrologie)
        {
            try
            {   int i = 0;
                // boucle sur les transactions
                for (i =0; i < transactions.Length; i++)
                { 


                
                }

                metrologie.nombretransaction = $"Nombre de transactions : {i}";
                Console.WriteLine(metrologie.nombretransaction);


            } catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

        }


        private Parse_csv.operationsComptes[] OperationEchange(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.operationsComptes[] operationsCreationCompte, 
                                     Parse_csv.operationsComptes[] operationsClotureCompte,int i, int k, int j, Parse_csv.transactionGestionnaires[] transactionGestionnaires)
        {
            Parse_csv.operationsComptes[] operationsEchange = new operationsComptes[operationsComptes.Length];
            int p = 0;
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
                                operationsEchange[p] = operationsComptes[i];
                                p++;

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
                                        operationsEchange[p] = operationsComptes[i];
                                        p++;
                                    }
                                }


                            }

                        }
                    }

                   

                }
            }

            return operationsEchange;
        }


        private int MontantTotalReussites(Parse_csv.operationsComptes[] operationsComptes,int i)
        {
            if (operationsComptes[i].soldeInitial.Equals("")) { operationsComptes[i].soldeInitial = "0"; };
            montantTotalReussites += Convert.ToInt32(operationsComptes[i].soldeInitial);

            return montantTotalReussites;
        }

    }
}