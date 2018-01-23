using System;
using System.Diagnostics;

namespace CoinCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reads a number from console
            Console.WriteLine("Write a number of cents to proccess or a letter to finish: ");
            string valueRead = Console.ReadLine();
            int required = 0;
            while (Int32.TryParse(valueRead, out required))
            {
                Console.WriteLine("Check value: " + required + " cents");

                Stopwatch stopwatch = Stopwatch.StartNew();
                calculatePossibilities(required);
                stopwatch.Stop();
                Console.WriteLine("Time elapsed to proccess using recursive strategy: " + stopwatch.ElapsedMilliseconds + "ms");
                Console.WriteLine();

                if (required > 200)
                {
                    Console.WriteLine("Nested loop strategy does not work with numbers higher than 200.");
                    Console.WriteLine();
                }
                else
                {
                    stopwatch = Stopwatch.StartNew();
                    calculatePossibilities2(required);
                    stopwatch.Stop();
                    Console.WriteLine("Time elapsed to proccess using nested loop strategy: " + stopwatch.ElapsedMilliseconds + "ms");
                    Console.WriteLine();
                }

                Console.WriteLine("Write a number of cents to proccess or a letter to finish: ");
                valueRead = Console.ReadLine();
            }
        }

        /// <summary>
        /// Calculate possibilities using recursive calls
        /// </summary>
        /// <param name="required"></param>
        public static void calculatePossibilities(int required)
        {
            // Create array of money available
            var money = new Money[]{
                new Money{
                    FaceValue = "50.00",
                    Value = 5000,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "20.00",
                    Value = 2000,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "10.00",
                    Value = 1000,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "5.00",
                    Value = 500,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.50",
                    Value = 50,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.20",
                    Value = 20,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.10",
                    Value = 10,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.05",
                    Value = 5,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.02",
                    Value = 2,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                },
                new Money
                {
                    FaceValue = "0.01",
                    Value = 1,
                    AmountAvailable = 0,
                    AmountUsed = 0,
                    ControlledAvailability = false
                }
            };

            int possibilitiesFound = checkPossibility(required, money);

            Console.WriteLine("Total possibilities found: " + possibilitiesFound);
        }

        /// <summary>
        /// Method auxiliar to be called recursively
        /// </summary>
        /// <param name="amountRequired">Amount of cents required</param>
        /// <param name="moneyAvaliable">Money array available</param>
        /// <param name="currentIndexChecking">Current index to check</param>
        /// <returns></returns>
        public static int checkPossibility(int amountRequired, Money[] moneyAvaliable, int currentIndexChecking = 0)
        {
            // TODO: Check avaliability of money

            // Avoid enter when amount found or out of index
            if (currentIndexChecking >= moneyAvaliable.Length || amountRequired == 0)
                return 0;

            var moneyChecking = moneyAvaliable[currentIndexChecking];

            // If amount required less than current money, check deeper
            if (amountRequired < moneyChecking.Value)
                return checkPossibility(amountRequired, moneyAvaliable, currentIndexChecking + 1);

            // If 1 cent, return 1 possibility found 
            if (moneyChecking.Value == 1)
                return 1;

            int exceed = (amountRequired % moneyChecking.Value);
            int maxUse = ((amountRequired - exceed) / moneyChecking.Value);

            int possibilitiesFound = 0;
            for (int used = 0; used <= maxUse; used++)
            {
                // Check for possibility found and return
                if ((used * moneyChecking.Value) == amountRequired)
                {
                    possibilitiesFound++;
                    break;
                }
                else
                {
                    possibilitiesFound += checkPossibility(amountRequired - (used * moneyChecking.Value), moneyAvaliable, currentIndexChecking + 1);
                }
            }

            return possibilitiesFound;
        }

        /// <summary>
        /// Calculate possibilities using nested loops
        /// </summary>
        /// <param name="required">Amount of cents required</param>
        public static void calculatePossibilities2(int required)
        {
            int possibilitiesFound = 0;
            for (int m5000 = 0; m5000 <= required; m5000 += 5000)
                for (int m2000 = 0; m2000 <= required; m2000 += 2000)
                    for (int m1000 = 0; m1000 <= required; m1000 += 1000)
                        for (int m500 = 0; m500 <= required; m500 += 500)
                            for (int m50 = 0; m50 <= required; m50 += 50)
                                for (int m20 = 0; m20 <= required; m20 += 20)
                                    for (int m10 = 0; m10 <= required; m10 += 10)
                                        for (int m5 = 0; m5 <= required; m5 += 5)
                                            for (int m2 = 0; m2 <= required; m2 += 2)
                                                for (int m1 = 0; m1 <= required; m1 += 1)
                                                    if (m5000 + m2000 + m1000 + m500 + m50 + m20 + m10 + m5 + m2 + m1 == required)
                                                        possibilitiesFound++;

            Console.WriteLine("Total possibilities found: " + possibilitiesFound);
        }
    }
}
