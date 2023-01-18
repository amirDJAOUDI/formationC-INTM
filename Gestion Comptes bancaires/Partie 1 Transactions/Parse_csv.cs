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
    public class compte
    {
        public int compteId;
        public string solde;
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
        public Parse_csv.compte[] Parse_CompteFile()
        {
            var fileHelperEngine = new FileHelperEngine<compte>();
            var comptes = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 1 Transactions\Comptes.csv");
            return comptes;
        }

        public Parse_csv.transaction[] Parse_TransactionFile()
        {
            var fileHelperEngine = new FileHelperEngine<transaction>();
            var transactions = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 1 Transactions\Transactions.csv");
            return transactions;
        }

        public void WriteTransactionStatus(Parse_csv.transactionStatus[] writeTransaction)
        {
            var fileHelperEngine = new FileHelperEngine<transactionStatus>();
            fileHelperEngine.WriteFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 1 Transactions\StatutsTransactions.csv", writeTransaction);
        }
    }
}