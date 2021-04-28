using System;
namespace GraphTask
{
    class App
    {
        static void Main(string[] args)
        {
            int[,] matrix1 =
            {
                {0, 1, 0, 0, 0, 0, 0 },
                {1, 0, 1, 1, 1, 1, 0 },
                {0, 1, 0, 0, 0, 0, 1 },
                {0, 1, 0, 0, 0, 0, 0 },
                {0, 1, 0, 0, 0, 1, 0 },
                {0, 1, 0, 0, 1, 0, 1 },
                {0, 0, 1, 0, 0, 1, 0 }
            };

            int[,] matrix2 = {
                { 0, 1, 0, 0, 0, 1, 1},
                { 1, 0, 0, 0, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 0, 0, 0, 0, 0},
                { 1, 1, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0}
            };

            Graph graph1 = new Graph(matrix2);
            Graph graph2 = new Graph(matrix1);

            graph1.PassInWidth(Console.WriteLine);

            Console.WriteLine();

            graph2.PassInDepth(Console.WriteLine);
        }
    }
}
