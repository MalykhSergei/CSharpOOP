using System.Collections.Generic;

namespace LambdaTask
{
    class Utils
    {
        public static IEnumerable<int> GetNumbersStream()
        {
            int i = 0;

            while (true)
            {
                yield return i;

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
