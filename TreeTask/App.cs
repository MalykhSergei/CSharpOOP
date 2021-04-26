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
            tree.Add(7);
            tree.Add(10);
            tree.Add(1);
            tree.Add(30);
            tree.Add(42);

            tree.PassInDepthWithRecursion(Console.WriteLine);
        }
    }
}
