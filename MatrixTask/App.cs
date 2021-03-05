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


            // double[] resArray = new double[array1.GetLength(0)];

            //for (int i = 0; i < resArray.Length; i++)
            // {
            //     resArray[i] = array1[i, 0];
            // }

            //for (int i =  0; i < resArray.Length; i++)
            // {
            //     Console.WriteLine(resArray[i]);
            // }

            double[] array2 = new double[] { 3, 4, 1, 2 };

            double[] array4 = new double[] { 6, 6 };

            double[] array3 = new double[] { 3, 4, 3 };

            Vector[] vectors = new Vector[]
            {
                new Vector(array2),
                new Vector(array3),
                new Vector(5, array4)
            };


            Matrix matrix = new Matrix(vectors);

            Console.WriteLine(matrix);
        }
    }
}
