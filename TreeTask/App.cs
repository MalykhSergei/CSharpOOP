using System;

namespace TreeTask
{
    class App
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(12);
            tree.Add(21);
            tree.Add(6);
            tree.Add(10);
            tree.Add(1);
            tree.Add(30);
            tree.Add(42);
            tree.Add(90);

            Console.WriteLine(tree.Count);

            Console.WriteLine();

            tree.PassInDepthWithRecursion(Console.WriteLine);

            Console.WriteLine();

            foreach (int item in tree.PassInDepthWithoutRecursion())
            {
                Console.WriteLine(item);
            }
        }
    }
}