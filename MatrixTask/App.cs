using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[,] array = new double[,]
            {
                { 2, 4, 3 },
                { 3, 8, 5 }
            };

            double[] arr = { };

            Console.WriteLine(arr.Length);

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
