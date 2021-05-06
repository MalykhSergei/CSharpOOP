using System;
using System.Collections.Generic;

namespace GraphTask
{
    class Graph
    {
        private readonly int[,] graph;

        public Graph(int[,] graph)
        {
            int rowsCount = graph.GetLength(0);
            int columnsCount = graph.GetLength(1);

            if (graph is null)
            {
                throw new ArgumentNullException(nameof(graph), "Graph is empty!");
            }

            if (rowsCount == 0)
            {
                throw new ArgumentException($"{nameof(rowsCount)} = 0. The number of rows in the array must be greater than 0", nameof(graph));
            }

            if (columnsCount == 0)
            {
                throw new ArgumentException($"{nameof(columnsCount)} = 0. The number of columns in the array must be greater than 0", nameof(graph));
            }

            if (rowsCount != columnsCount)
            {
                throw new InvalidOperationException($"The count of rows = {rowsCount}, the count of columns = {columnsCount}. There must be a square matrix!");
            }

            this.graph = graph;
        }

        public void PassInWidth(Action<int> action)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.Length];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (visited[i])
                {
                    continue;
                }

                queue.Enqueue(i);

                while (queue.Count != 0)
                {
                    int currentNode = queue.Dequeue();

                    if (visited[currentNode])
                    {
                        continue;
                    }

                    visited[currentNode] = true;
                    action(currentNode);

                    for (int j = 0; j < graph.GetLength(0); j++)
                    {
                        if (!visited[j] && graph[currentNode, j] == 1)
                        {
                            queue.Enqueue(j);
                        }
                    }
                }
            }
        }

        private void VisitNode(int node, bool[] visited, Action<int> action)
        {
            if (!visited[node])
            {
                visited[node] = true;
                action(node);

                for (int i = 0; i < visited.Length; i++)
                {
                    if (!visited[i] && graph[node, i] == 1)
                    {
                        VisitNode(i, visited, action);
                    }
                }
            }
        }

        public void PassInDepth(Action<int> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action), "Action is null");
            }

            bool[] visited = new bool[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    VisitNode(i, visited, action);
                }
            }
        }

        public void PassInDepthWithoutRecursion(Action<int> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action), "Action is null");
            }

            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[graph.Length];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (visited[i])
                {
                    continue;
                }

                stack.Push(i);

                while (stack.Count != 0)
                {
                    int currentNode = stack.Pop();

                    if (visited[currentNode])
                    {
                        continue;
                    }

                    visited[currentNode] = true;
                    action(currentNode);

                    for (int j = graph.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (!visited[j] && graph[currentNode, j] == 1)
                        {
                            stack.Push(j);
                        }
                    }
                }
            }
        }
    }
}
