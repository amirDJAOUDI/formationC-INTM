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
        int retraitMax = 1000;

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
                                    operationsClotureCompte[l] = operationsComptes[i];
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

                OperationTransaction(operationsComptes, transactions, operationsCreationCompte, operationsClotureCompte, operationsEchangeCompte, metrologie, K, j) ;

            }

            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

        }

        public void OperationTransaction(Parse_csv.operationsComptes[] operationsComptes, Parse_csv.transactions[] transactions, 
                                         Parse_csv.operationsComptes[] operationsCreationCompte, Parse_csv.operationsComptes[] operationsClotureCompte,
                                         Parse_csv.operationsComptes[] operationsEchangeCompte, Parse_csv.metrologie metrologie, int K, int j)
        {
            try
            {   int i = 0;
                int r = 0;
                // boucle sur les transaction
                for (i =0; i < transactions.Length; i++)
                {
                    if (transactions[i].montant < retraitMax)
                    {

                        //if (transactions[i].transactionId == 3) {
                        // verfifier que le ou les comptes sont créés:
                        if (VerifCreationCompte(transactions[i], operationsCreationCompte, K))
                        {
                            // verifier que le compte n'est pas clos
                            if (!VerifClotureCompte(transactions[i], operationsClotureCompte, j))
                            {
                                Console.WriteLine("***********Transaction OK transactionId: " + transactions[i].transactionId);
                                r++;
                                montantTotalReussites += transactions[i].montant;
                            }

                       //}
                        }

                    }


                }


                Console.WriteLine("*********************************************");
                Console.WriteLine("*******Fichier des transactions**************");
                metrologie.statistique = "Statistiques :";
                Console.WriteLine(metrologie.statistique);

                metrologie.nombreComptes = $"Nombre de comptes : {K}";
                Console.WriteLine(metrologie.nombreComptes);

                metrologie.nombretransaction = $"Nombre de transaction : {i}";
                Console.WriteLine(metrologie.nombretransaction);

                metrologie.nombreReussites = $"Nombre de réussites : {r}";
                Console.WriteLine(metrologie.nombreReussites);

                metrologie.nombreEchecs = $"Nombre d'échecs : {(i - (r))}";
                Console.WriteLine(metrologie.nombreEchecs);

                metrologie.montantTotalReussites = $"Montant total des réussites : {montantTotalReussites}";
                Console.WriteLine(metrologie.montantTotalReussites);

                Console.WriteLine("*********************************************");




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

        private bool VerifCreationCompte(Parse_csv.transactions transaction, Parse_csv.operationsComptes[] operationsCreationCompte, int K)
        {    

            for (int j = 0; j < K; j++)
            {

                if (transaction.compteIdExped != 0 && transaction.compteIdDest != 0 && transaction.compteIdExped.Equals(operationsCreationCompte[j].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsCreationCompte[j].date))
                {

                    for (int n = 0; n < K; n++) {


                        if (transaction.compteIdDest.Equals(operationsCreationCompte[n].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsCreationCompte[n].date)) 
                        { return true; }
                    }

                }
                else
                {
                    if (transaction.compteIdExped != 0 && transaction.compteIdExped.Equals(operationsCreationCompte[j].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsCreationCompte[j].date))
                    { return true; }

                    if (transaction.compteIdDest != 0 && transaction.compteIdDest.Equals(operationsCreationCompte[j].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsCreationCompte[j].date))
                    { return true; }
                }

            }

            return false;
        }

        private bool VerifClotureCompte(Parse_csv.transactions transaction, Parse_csv.operationsComptes[] operationsClotureCompte, int K)
        {

            for (int j = 0; j < K; j++)
            {

                if (transaction.compteIdExped != 0 && transaction.compteIdDest != 0 && transaction.compteIdExped.Equals(operationsClotureCompte[j].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsClotureCompte[j].date))
                {

                    for (int n = 0; n < K; n++)
                    {
                        if (transaction.compteIdDest.Equals(operationsClotureCompte[n].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsClotureCompte[n].date))
                        { return true; }
                    }

                } else {
                    if (transaction.compteIdExped != 0 && transaction.compteIdExped.Equals(operationsClotureCompte[j].compteId)
                        && Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsClotureCompte[j].date))
                    { return true; }

                    if (transaction.compteIdDest != 0 && transaction.compteIdDest.Equals(operationsClotureCompte[j].compteId)
                        && (Convert.ToDateTime(transaction.dateEffet) > Convert.ToDateTime(operationsClotureCompte[j].date)))
                    { return true; }
                }

            }

            return false;
        }


    }
}