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
        public string date;
        public string soldeInitial;
        public string entree;
        public string sortie;
    }

    [DelimitedRecord(";")]
    public class transactions
    {
        public int transactionId;
        public string dateEffet;
        public int montant;
        public int compteIdExped;
        public int compteIdDest;
        public string statut;
    }

    [DelimitedRecord(";")]
    public class transactionGestionnaires
    {
        public int gestionnaireid;
        public string transactionTyp;
        public int transationNumbers;
    }

    [DelimitedRecord(";")]
    public class statutsTransactions
    {
        public int transactionId;
        public string statut;
    }

    [DelimitedRecord(";")]
    public class statutsOperations
    {
        public int operationId;
        public string statut;
    }

    public class metrologie
    {
        public string statistique;
        public string nombreComptes;
        public string nombretransaction;
        public string nombreReussites;
        public string nombreEchecs;
        public string montantTotalReussites;
        public string fraisGestion;
        public string identifiantGestion;
    }


    class ParseFiles
    {
        public Parse_csv.operationsComptes[] Parse_OperationsComptes()
        {
            var fileHelperEngine = new FileHelperEngine<operationsComptes>();
            var operationsComptes = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\OperationsComptes.csv");
            return operationsComptes;
        }

        public Parse_csv.transactions[] Parse_TransactionsFile()
        {
            var fileHelperEngine = new FileHelperEngine<transactions>();
            var transactions = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\Transactions.csv");
            return transactions;
        }

        public Parse_csv.transactionGestionnaires[] Parse_TransactionGestionnairesFile()
        {
            var fileHelperEngine = new FileHelperEngine<transactionGestionnaires>();
            var transactionGestionnaires = fileHelperEngine.ReadFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\TransactionGestionnaires.csv");
            return transactionGestionnaires;
        }


        public void WriteStatutsTransactions(Parse_csv.statutsTransactions[] writeStatutsTransactions)
        {
            var fileHelperEngine = new FileHelperEngine<statutsTransactions>();
            fileHelperEngine.WriteFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\StatutsTransactions.csv", writeStatutsTransactions);
        }

        public void WriteStatutsOperations(Parse_csv.statutsOperations[] writeStatutsOperations)
        {
            var fileHelperEngine = new FileHelperEngine<statutsOperations>();
            fileHelperEngine.WriteFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\StatutsOperations.csv", writeStatutsOperations);
        }

        public void WriteMetrologie(Parse_csv.metrologie[] writeMetrologie)
        {
            var fileHelperEngine = new FileHelperEngine<metrologie>();
            fileHelperEngine.WriteFile(@"C:\Users\Azul\source\repos\amirDJAOUDI\formationC-INTM\Gestion Comptes bancaires\Partie 2 Comptes et metrologie\StatutsOperations.csv", writeMetrologie);
        }
    }
}