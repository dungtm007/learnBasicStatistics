using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStatistics
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            string valuesStr = Console.ReadLine();
            string[] valuesArr = valuesStr.Split(' ');
            string freqStr = Console.ReadLine();
            string[] freqArr = freqStr.Split(' ');

            List<int> fullValues = new List<int>();
            for (int i = 0; i < valuesArr.Length; i++)
            {
                var ele = Convert.ToInt32(valuesArr[i]);
                var freq = Convert.ToInt32(freqArr[i]);
                fullValues.AddRange(Enumerable.Repeat(ele, freq));
            }

            var quartiles = Quartiles(fullValues);

            Console.WriteLine(string.Format("{0:0.0}", quartiles[2] - quartiles[0]));
        }

        public static List<double> Quartiles(List<int> values)
        {
            // Sort the list from small to large
            values.Sort();

            int num = values.Count;
            int midIndQ1, midIndQ2 = num / 2, midIndQ3;
            double Q1, Q2, Q3;

            // Find Quartile 2
            if (num % 2 == 0) // num is even
            {
                Q2 = (values[midIndQ2 - 1] + values[midIndQ2]) / 2.0;
            }
            else // num is odd
            {
                Q2 = values[midIndQ2];
            }

            // Find Quartile 1 & 3
            int numHalf = num / 2;
            if (numHalf % 2 == 0) // numHalf is even: 8-4; 9-4
            {
                midIndQ1 = numHalf / 2; // any num 
                midIndQ3 = (midIndQ2 + 1 + num) / 2; // numIsEven ? (midIndQ2 + num - 1) / 2 : (midIndQ2 + num);

                Q1 = (values[midIndQ1 - 1] + values[midIndQ1]) / 2.0;
                Q3 = (values[midIndQ3 - 1] + values[midIndQ3]) / 2.0;

            }
            else // half is odd
            {
                midIndQ1 = numHalf / 2; // any num 
                midIndQ3 = (midIndQ2 + num) / 2;

                Q1 = values[midIndQ1];
                Q3 = values[midIndQ3];
            }

            return new List<double>() { Q1, Q2, Q3 };
        }
    }
}
