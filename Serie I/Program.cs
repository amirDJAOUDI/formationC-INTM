using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Keep the console window open
            Console.WriteLine("----------------------");
            ElementaryOperations elemOper = new ElementaryOperations();
            Console.WriteLine("Start ElementaryOperations ");
            Console.WriteLine("BasicOperation ");
            elemOper.BasicOperation(2, 0, '/');
            Console.WriteLine("IntegerDivision ");
            elemOper.IntegerDivision(1, 3);
            Console.WriteLine("Pow ");
            elemOper.Pow(3, 5);
            Console.WriteLine("End ElementaryOperations");

            Pyramid pyramid = new Pyramid();
            pyramid.PyramidConstruction(10, true);
        }
    }
}
