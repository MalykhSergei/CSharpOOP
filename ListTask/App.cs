using System;

namespace ListTask
{
    class App
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();

            list1.Add(2);
            list1.AddFirst(1);

            list1.Insert(2, 10);

            Console.WriteLine(list1);
        }
    }
}
