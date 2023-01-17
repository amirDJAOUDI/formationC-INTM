using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using Parse_csv;

namespace CompteBancaire
{

   

    class Program
    {


        static void Main(string[] args)
        {

           Parse_csv.ParseFiles parsFile = new Parse_csv.ParseFiles();

            // parse du fichier d'entrée "compte"
            Parse_csv.compte[] comptesFile = parsFile.Parse_CompteFile();

            // parse du fichier d'entrée "transaction"            
            Parse_csv.transaction[] transactionsFile = parsFile.Parse_TransactionFile();
            

                // Boucle sur les transactions
                Compte compte = new Compte();
                List<int> ListSansDuplication = new List<int>();
                int j = 0;

            for (int i = 0;i < transactionsFile.Length; i++)
            {

                if (!ListSansDuplication.Contains(transactionsFile[i].transactionId)) 
                {
                    ListSansDuplication.Add(transactionsFile[i].transactionId);
                    j++;
                }

            }

            Parse_csv.transactionStatus[] listtransStatus = new Parse_csv.transactionStatus[j];
            ListSansDuplication = new List<int>();
            int k= 0;

            for (int i = 0; i < transactionsFile.Length; i++)
            {

                if (!ListSansDuplication.Contains(transactionsFile[i].transactionId))
                {
                    ListSansDuplication.Add(transactionsFile[i].transactionId);

                    listtransStatus[k] = new Parse_csv.transactionStatus();
                    listtransStatus[k].transactionId = transactionsFile[i].transactionId;
                    k++;

                    if (compte.EchangeArgent(transactionsFile[i].montant, transactionsFile[i].compteIdExped, transactionsFile[i].compteIdDest, comptesFile))
                    {
                        listtransStatus[i].status = "OK";
                    }
                    else { listtransStatus[i].status = "KO"; }

                }

            }

            // Ecriture du fichier de sortie "transaction"
            parsFile.WriteTransactionStatus(listtransStatus);

        }
    }
}