using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperations
{

    //Calculate the total from given string
    class ArithmeticCalculations
    {
        char[] delimiterChars = { '*', '/', '-', '+' };
        double total = 0;
        public double CalculateData(string sData)
        {
            
            // Split string by arithmetic operators
            string[] spNum = sData.Split(delimiterChars);

            Console.WriteLine(" ");
            Console.WriteLine("Entered Numbers");
            foreach (var num in spNum)
            {
                Console.WriteLine($"<{num}>");
            }


            // Operators added in List
            List<string> operators = new List<string>();
            for (int i = 0; i < sData.Length; i++)
            {
                String s = sData.Substring(i, 1);
                if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"))
                    operators.Add(s);
            }

            Console.WriteLine(" ");
            Console.WriteLine("Operators");
            foreach (var symbol in operators)
            {
                Console.WriteLine($"{symbol}");
            }


            //////Operator Precedence///////

            //for multiplication
            int opIndex;
            double multiValue = 0;
            if (operators.Contains("*"))
            {
                opIndex = operators.FindIndex(x => x == "*");
                multiValue = (Convert.ToDouble(spNum[opIndex]) * Convert.ToDouble(spNum[opIndex + 1]));
                spNum[opIndex] = "0";
                spNum[opIndex + 1] = "0";
                total = multiValue;

            }


            //for division
            double divValue = 0;
            if (operators.Contains("/"))
            {
                opIndex = operators.FindIndex(x => x == "/");
                if (multiValue == 0)
                {
                    divValue = Convert.ToDouble(spNum[opIndex]) / Convert.ToDouble(spNum[opIndex + 1]);
                    spNum[opIndex] = "0";
                    spNum[opIndex + 1] = "0";
                }
                else
                {
                    divValue = multiValue / Convert.ToDouble(spNum[opIndex + 1]);
                    spNum[opIndex + 1] = "0";
                }
                total = divValue;
            }

            //for addition
            double addValue = 0;
            if (operators.Contains("+"))
            {
                opIndex = operators.FindIndex(x => x == "+");
                if (multiValue == 0 && divValue == 0)
                    addValue = Convert.ToDouble(spNum[opIndex]) + Convert.ToDouble(spNum[opIndex + 1]);
                else
                    addValue = divValue + Convert.ToDouble(spNum[opIndex]) + Convert.ToDouble(spNum[opIndex + 1]);
                total = addValue;
            }

            //for substaction
            double subValue = 0;
            if (operators.Contains("-"))
            {
                opIndex = operators.FindIndex(x => x == "-");
                subValue = addValue - Convert.ToDouble(spNum[opIndex + 1]);
                total = subValue;
            }

            //returns calculated value
            return total;
        }
    }
}
