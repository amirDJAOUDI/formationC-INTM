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

        private int[][] tabGrilles = new int[6][];

        Random rnd = new Random();
        Percolation Perc = new Percolation();
        int nombreCaseOpen = 0;

      public int PercolationSimul() {

            for (int i = 0; i < 36; i++)
            {
                Perc.Open(5 * rnd.Next(), 5 * rnd.Next());
                nombreCaseOpen++;

            }
            return nombreCaseOpen/ 36;
        }



        public PclData MeanPercolationValue(int size, int t)
        {
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            return 0;
        }
    }
}
