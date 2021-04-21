using System;
using System.Collections.Generic;

namespace LambdaTask
{
    class Utils
    {
        public static IEnumerable<double> GetSquareRootsNumbersStream()
        {
            int i = 0;

            while (true)
            {
                yield return Math.Sqrt(i);

                i++;
            }
        }

        public static IEnumerable<int> GetFibonacciNumbersStream()
        {
            int currentFibonacciNumber = 0;
            int nextFibonacciNumber = 1;

            while (true)
            {
                yield return currentFibonacciNumber;

                int temp = nextFibonacciNumber;
                nextFibonacciNumber += currentFibonacciNumber;
                currentFibonacciNumber = temp;
            }
        }
    }
}
