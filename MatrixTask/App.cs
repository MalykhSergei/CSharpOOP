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

            double[,] array = new double[,] { { 0, 3 }, { 1, 5} };

            double[] array1 = new double[] { 2, 3, 0 };
            double[] array2 = new double[] { 3, 4, 1 };

            Matrix matrix1 = new Matrix(array);
            Matrix matrix2 = new Matrix(matrix1);




            Console.WriteLine(matrix1);

        }
    }
}
