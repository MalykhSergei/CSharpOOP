using System;
using System.Text;

namespace MatrixTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[,] array =
            {
                { 2, 4, 3 },
                { 3, 8, 5 }
            };

            Matrix matrix = new Matrix(array);

            Console.WriteLine(matrix);
        }
    }
}
