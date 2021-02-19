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

            double[,] array = new double[,] { { 0, 3 }, { 1, 5 }, { 4, 5 } };

            double[] array1 = new double[] { 2, 3, 0, 1 };
            double[] array2 = new double[] { 3, 4, 1, 2 };
            double[] array3 = new double[] { 3, 4, 1, 6 };

            Vector[] vectors = new Vector[]
            {
                new Vector(array1),
                new Vector(array2)
            };

            Matrix matrix = new Matrix(vectors);

            Console.WriteLine(matrix);

        }
    }
}
