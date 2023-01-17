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
        private int retraitAutorise =1000;

        public Compte()
        {
 
        }
        public bool EchangeArgent( int montant, int compteIdExped, int compteIdDest, Parse_csv.compte[] comptesFile)
        {
            try
            {   
                // sauvegarde du solde initial
                Parse_csv.compte[] comptesFileSav = comptesFile;

                // définir le type d'échange
                string typeEchange = TypeEchange(compteIdExped, compteIdDest);

            switch (typeEchange)
            {
                case "DEPOT":
                    // récuperer le compte à créditer
                    Parse_csv.compte compteCrediter = VerifCompte(compteIdDest, comptesFile);
                    return Crediter(montant, compteCrediter);

                case "RETRAIT":

                        // récuperer le compte à debiter
                        Parse_csv.compte compteDebiter = VerifCompte(compteIdExped, comptesFile);
                        return Debiter(montant, compteDebiter, comptesFileSav);

                case "VIREMENT/PRELEVEMENT":

                        // débiter le compte expediteur et créditer le compte destinataire
                        compteDebiter = VerifCompte(compteIdExped, comptesFile);

                        if (Debiter(montant, compteDebiter, comptesFileSav)) 
                        {
                            compteCrediter = VerifCompte(compteIdDest, comptesFile);
                            return Crediter(montant, compteCrediter);
                        } 
                    break;

                default:

                    throw new ArgumentException("Type d'opération non prise en charge: ", typeEchange);
            }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            return false;

        }

        private bool Crediter(int montant, Parse_csv.compte compte)
        {    
            if (compte.solde.Equals("")) 
            { compte.solde = "0"; }

            if (montant >= 0)
            {
                double solde = montant + Convert.ToDouble(compte.solde, new CultureInfo("en-US"));
                compte.solde = Convert.ToString(solde);

                return true;
            }
            else
            {
                throw new ArgumentException(" Le montant du dépôt doit être positif: ", Convert.ToString(montant));
            }
        }
        private bool Debiter(int montant, Parse_csv.compte compte, Parse_csv.compte[] compteFileSav)
        {
            
            if (compte.solde.Equals(""))
            { compte.solde = "0"; }

            double solde = Convert.ToDouble(compte.solde, new CultureInfo("en-US"));

            if (montant >= 0 && solde > montant && IsAmountexceed(compte, compteFileSav, montant))
            {
                
                solde -= montant;
                compte.solde = Convert.ToString(solde);

                return true;

            }
            return false;
        }

        private bool IsAmountexceed(Parse_csv.compte compte, Parse_csv.compte[] compteSav, int montant)

        {
            for (int i = 0; i < compteSav.Length; i++)
            {  
                if (compteSav[i].compteId.Equals(compte.compteId) && ((Convert.ToDouble(compteSav[i].solde, new CultureInfo("en-US")) - Convert.ToDouble(compte.solde, new CultureInfo("en-US")) + montant) <= retraitAutorise))
                {
                    return true;
                }
            }
            return false;
        }

        private string TypeEchange(int compteIdExped, int compteIdDest)
        {
            string typeEchange = "";

            if (compteIdExped == 0)
            { typeEchange = "DEPOT"; }

            if (compteIdDest == 0)
            { typeEchange = "RETRAIT"; }

            if (compteIdExped > 0 && compteIdDest > 0)
            { typeEchange = "VIREMENT/PRELEVEMENT"; }

            return typeEchange;

        }

        private Parse_csv.compte VerifCompte(int IdCompte, Parse_csv.compte[] comptesFile)
        {
            for (int i =0; i < comptesFile.Length; i++)
            {

                if (comptesFile[i].compteId == IdCompte)
                {
                    return comptesFile[i];
                }
            }
                
                throw new ArgumentException(" Id du compte : " + IdCompte + " n'est pas présent dans le fichier des comptes!");
            
        }

    }
}