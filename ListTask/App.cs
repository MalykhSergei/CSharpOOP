using System;

namespace ListTask
{
    class App
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();
            _ = new LinkedList<int>();

            list1.Add(2);
            list1.Add(3);
            list1.AddFirst(12);
            list1.Add(120);

            Console.WriteLine(list1.RemoveByValue(2));

            LinkedList<int> list2 = list1.Copy();

            list2.Add(4);

            Console.WriteLine(list2);
        }
    }
}
