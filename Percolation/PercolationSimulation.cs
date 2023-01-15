using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        Percolation Perc = new Percolation(6);
       

      public void PercolationSimul() {

           
            double percoValue = PercolationValue(36);
            Console.WriteLine("percoValue: " + percoValue);
 
            
        }

        public PclData MeanPercolationValue(int size, int t)
        {
            // Calcul de moyenne et d'écart-type
            double meanPercoValue = 0;
            double[] listPercoValue = new double[t];
            PclData pclData = new PclData();

            // recuperation de la liste des valeurs de percolation
            for (int i = 0; i < t; i++) {

                listPercoValue[i] = PercolationValue(size);
            }

            // Calcul de moyenne
            meanPercoValue = listPercoValue.Average();
            Console.WriteLine("meanPercoValue: " + meanPercoValue);
            pclData.Mean = meanPercoValue;

            // Calcul d'écart-type:
            double sum = listPercoValue.Sum(d => Math.Pow(d - meanPercoValue, 2));
            double standard_deviation = Math.Sqrt((sum) / listPercoValue.Count());
            Console.WriteLine("standard_deviation: " + standard_deviation);
            pclData.StandardDeviation = standard_deviation;

            return pclData;
        }

        public double PercolationValue(int size)
        {
            Random rnd = new Random();
            Percolation Perco = new Percolation(size);
            int index = Convert.ToInt32(Math.Sqrt(size));
            int nombreCaseOpen = 0;
            double percoValue = 0;

            for (int i = 0; i < size; i++)
            {
                Perco.Open(rnd.Next(0, index), rnd.Next(0, index));
                ++nombreCaseOpen;

                if (Perco.isPercolation())
                {
                    percoValue = (double)nombreCaseOpen / size;
                    return percoValue;
                }
            }

            return percoValue;
        }
    }
}
