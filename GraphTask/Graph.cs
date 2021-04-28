using System;
using System.Collections.Generic;

namespace GraphTask
{
    class Graph
    {
        private readonly int[,] graph;

        public Graph(int[,] graph)
        {
            this.graph = graph;
        }

        public void PassInWidth(Action<int> action)
        {
            if (graph.Length == 0)
            {
                throw new ArgumentNullException(nameof(graph), "Graph is empty");
            }

            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.Length];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);

                    while (queue.Count != 0)
                    {
                        int currentNode = queue.Dequeue();

                        if (!visited[currentNode])
                        {
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
            if (graph.GetLength(0) == 0)
            {
                if (graph.Length == 0)
                {
                    throw new ArgumentNullException(nameof(graph), "Graph is empty");
                }
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
    }
}
