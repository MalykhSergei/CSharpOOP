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

            double[,] array = new double[,] { { 0, -1 }, { 1, 3 } };

            double[] array1 = new double[] { 2, 3, 0 };
            double[] array2 = new double[] { 3, 4, 1 };

            Matrix matrix = new Matrix(3, 5);

            Vector vector = new Vector(array2);

            Vector[] vectors = new Vector[] { new Vector(array1), new Vector(array2) };

            Matrix matrix2 = new Matrix(array);

            Console.WriteLine(matrix);
        }
    }
}
