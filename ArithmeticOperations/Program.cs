using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperations
{
    class Program
    {
        // The code only considers operators in string only once.
        // Will consider : 1+2 * 5 / 3-4
        // but will not consider : 1+2 * 5 / 3+4
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value:" );
            string data = Console.ReadLine();

            ArithmeticCalculations objCal = new ArithmeticCalculations();

            double dataAns = objCal.CalculateData(data.Trim());

            Console.WriteLine(" ");
            Console.WriteLine("Total Calculated values: {0}", System.Math.Round(dataAns, 3));
            Console.ReadLine();
        }
    }
}
