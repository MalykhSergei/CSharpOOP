using System;
using System.Collections.Generic;

namespace LambdaTask
{
    class Utils
    {
        public static IEnumerable<double> GetSquareRootsNumbersStream(int itemsCount)
        {
            int i = 0;

            while (i <= itemsCount)
            {
                yield return Math.Sqrt(i);

                i++;
            }
        }

        public static IEnumerable<int> GetFibbonacciNumbers(int itemsCount)
        {
            int currentFibonacciNumber = 0;
            int nextFibonacciNumber = 1;

            for (int i = 0; i < itemsCount; i++)
            {
                int temp = currentFibonacciNumber;
                currentFibonacciNumber += nextFibonacciNumber;
                nextFibonacciNumber = temp;

                yield return currentFibonacciNumber;
            }
        }
    }
}
