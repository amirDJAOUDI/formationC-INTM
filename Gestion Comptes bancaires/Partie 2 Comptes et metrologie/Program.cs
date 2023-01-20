using System;
using System.Collections.Generic;
using System.IO;
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
            Parse_csv.operationsComptes[] operationsComptes = parsFile.Parse_OperationsComptes();

            // parse du fichier d'entrée "transactionGestionnaire"            
            Parse_csv.transactions[] transactions = parsFile.Parse_TransactionsFile();

            // parse du fichier d'entrée "transaction"            
            Parse_csv.transactionGestionnaires[] transactionGestionnaires = parsFile.Parse_TransactionGestionnairesFile();

            // Boucle sur les opérations sur compte
            Compte compte = new Compte();
            compte.OperationComptes(operationsComptes, transactionGestionnaires);   


            // Ecriture du fichier de sortie "transaction"
            //parsFile.WriteTransactionStatus(listtransStatus);

            
        }
            
    }
            
}