#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DailyRate
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        public void run()
        {
            //double fee = calculateFee();
            //double fee = calculateFee(650.0);
            //double fee = calculateFee(500.0, 3);
            //double fee = calculateFee(dailyRate : 375.0);
            //double fee = calculateFee(noOfDays : 4);
            double fee = calculateFee(theDailyRate : 375.0);
            Console.WriteLine("Fee is {0}", fee);
        }

        private double calculateFee(double theDailyRate = 500.0, int noOfDays = 5)
        {
            Console.WriteLine("calculateFee using two optional parameters");
            return theDailyRate * noOfDays;
        }

        private double calculateFee(double dailyRate = 500.0)
        {
            Console.WriteLine("calculateFee using one optional parameter");
            int defaultNoOfDays = 1;
            return dailyRate * defaultNoOfDays;
        }

        private double calculateFee()
        {
            Console.WriteLine("calculateFee using hardcoded values");
            double defaultDailyRate = 400.0;
            int defaultNoOfDays = 1;
            return defaultDailyRate * defaultNoOfDays;
        }
    }
}
