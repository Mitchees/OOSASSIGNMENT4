using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oosAssignment4
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */

    /*
     * Name: MITCHELL ANINYANG, 000796709
     * 
     * ==================================
     * STATEMENT OF AUTHORSHIP
     * ==================================
     * 
     * I certify that all code submitted is my own work; 
     * that I have not copied it from any other source.  
     * I also certify that I have not allowed my work to be copied by others.
     * 
     */
    public class A4
    {
        /// <summary>
        /// Method name = Avg
        /// This will calculate the average
        /// I took out the bool incneg argument from the this method
        /// 
        /// i am going to round the result of this method to 2 decimal places
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Avg(List<double> x)
        {
            double sum = Sum(x);    //Previously known as int s = Sum(x);
            int counter = 0;        //previously known as int c = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] >= 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            //return (sum / counter);

            return Math.Round((sum / counter) , 3);         //rounding the average to 2 decimal places
        }

        /// <summary>
        /// This is the sum
        /// 
        /// i will round the result of this method to 2 decimal places
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Sum(List<double> x)
        {
            if (x.Count < 0)
            {
                throw new ArgumentException("x cannot be empty");
            }

            double sum = 0.0;
            foreach (double value in x)     //previously known as double val in x
            {
                if (value >= 0)
                {
                    sum += value;
                }
            }
            return Math.Round(sum, 3);
        }

        /// <summary>
        /// This wilil calculate the median
        /// 
        /// I will round the result of this calculation to 2 decimal places
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Median(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            data.Sort();

            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return Math.Round(median, 3);
        }

        /// <summary>
        /// This will calculate the standard deviation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double SD(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int n = data.Count;
            double s = 0;
            double a = Avg(data);

            for (int i = 0; i < n; i++)
            {
                double v = data[i];
                s += Math.Pow(v - a, 2);
            }
            double stdev = Math.Sqrt(s / (n - 1));
            return Math.Round(stdev, 3);
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            //List of numbers
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            //Changing the background color
            Console.ForegroundColor = ConsoleColor.Green;

            //printing the sum of all the numbers in the TestDataD array
            Console.WriteLine("The sum of the array = {0}", Sum(testDataD));

            //printing the average of all the numbers in the TestDataD array
            Console.WriteLine("The average of the array = {0}", Avg(testDataD));

            //printing the Median of all the numbers in the TestDataD array
            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            //printing the Standard deviation of all the numbers in the TestDataD array
            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testDataD));

            Console.ReadLine();
        }
    }
}