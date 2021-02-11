using System;
using System.Text;

namespace VectorTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[] array1 = { 6, 7, 2, 10, 2 };

            double[] array2 = {};

            Vector vector1 = new Vector(array1);

            Vector vector2 = new Vector(array2);

            Vector vector = new Vector(vector1);

            Console.WriteLine(vector2);
        }
    }
}
