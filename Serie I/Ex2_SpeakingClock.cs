using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string affichage;

            if (heure >= 0 && heure <= 23) { 

                if (heure <= 6 )
                    { affichage = "Merveilleuse nuit !"; }
                else if (heure < 12)
                    { affichage = "Bonne matinée !"; } 
                else if (heure == 12)
                    { affichage = "Bon appétit !"; }
                else if (heure >= 18)
                    { affichage = "Profitez de votre après-midi !"; }

                else 
                    { affichage = "Passez une bonne soirée !"; }


            } else { affichage = "La valeur tapée n'est pas dans la plage horraire de 0 à 23H"; }

            return affichage;
        }
    }
}
