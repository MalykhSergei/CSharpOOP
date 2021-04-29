using System;
using System.Collections.Generic;

namespace LambdaTask
{
    class Utils
    {
        public static IEnumerable<double> GetSquareRootsNumbersStream()
        {
            var i = 0;

            while (true)
            {
                yield return Math.Sqrt(i);

                i++;
            }
        }

        public static IEnumerable<int> GetFibonacciNumbersStream()
        {
            var currentFibonacciNumber = 0;
            var nextFibonacciNumber = 1;

            while (true)
            {
                yield return currentFibonacciNumber;

                var temp = nextFibonacciNumber;
                nextFibonacciNumber += currentFibonacciNumber;
                currentFibonacciNumber = temp;
            }
        }
    }
}
