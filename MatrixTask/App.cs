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

            double[,] array1 = new double[,]
            {
                { 4, 2 },
                { 1, 2 },
                { 7, 1 }
            };

            double[] array2 = new double[] { 3, 4, 1, 2 };
            double[] array3 = new double[] { 3, 4, 3, 4 };

            Vector[] vectors = new Vector[]
            {
                new Vector(array2),
                new Vector(array3)
            };

            Matrix matrix = new Matrix(array);

            Console.WriteLine(matrix);
        }
    }
}
