using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace Parse_csv
{
    [DelimitedRecord(";")]
    public class operationsComptes
    {
        public int compteId;
        public DateTime dateTime;
        public string soldeInitial;
        public string entree;
        public string sortie;
        public int statut;
    }

    [DelimitedRecord(";")]
    public class transaction
    {
        public int transactionId;
        public int montant;
        public int compteIdExped;
        public int compteIdDest;
    }

    [DelimitedRecord(";")]
    public class transactionStatus
    {
        public int transactionId;
        public string status;
    }


    class ParseFiles
    {
        public Parse_csv.operationsComptes[] Parse_CompteFile()
        {
            var fileHelperEngine = new FileHelperEngine<operationsComptes>();
            var operationsComptes = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\operationsComptes.csv");
            return operationsComptes;
        }

        public Parse_csv.transaction[] Parse_TransactionFile()
        {
            var fileHelperEngine = new FileHelperEngine<transaction>();
            var transactions = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Transactions.csv");
            return transactions;
        }

        public void WriteTransactionStatus(Parse_csv.transactionStatus[] writeTransaction)
        {
            var fileHelperEngine = new FileHelperEngine<transactionStatus>();
            fileHelperEngine.WriteFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\StatutsTransactions.csv", writeTransaction);
        }
    }
}