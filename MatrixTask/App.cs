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

            double[] array2 = new double[] { 3, 4, 1 };

            double[] array4 = new double[] { 6, 6, 8, 9, 9, 8 };

            double[] array3 = new double[] {1 };

            Vector[] vectors = new Vector[]
            {
                new Vector(array2),
                new Vector(array3),
                new Vector(array4)
            };



            Matrix matrix = new Matrix(array1);

            matrix.Transpose();

            Console.WriteLine(matrix);
        }
    }
}
