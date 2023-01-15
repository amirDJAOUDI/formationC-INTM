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
            double[] listPercovalue= new double[t];

            for (int i = 0; i < t; i++) {

                listPercovalue[i] = PercolationValue(size);
            }


            return new PclData();
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
