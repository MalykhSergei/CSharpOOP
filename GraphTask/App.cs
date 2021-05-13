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

            int[,] matrix3 = null;

            Graph graph = new Graph(matrix3);

            graph.PassInDepth(Console.WriteLine);
        }
    }
}
