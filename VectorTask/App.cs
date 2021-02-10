using System;

namespace VectorTask
{
    class App
    {
        static void Main(string[] args)
        {
            double[] array1 = { 6, 7, 2, 10, 2 };

            double[] array2 = { 1, 2, 3, 4 };

            Vector vector1 = new Vector(array1);

            Vector vector2 = new Vector(array2);

            Console.WriteLine(string.Join(", ", Vector.GetScalarMultiplication(vector1, vector2)));
        }
    }
}
