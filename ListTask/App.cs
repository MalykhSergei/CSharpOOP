using System;

namespace ListTask
{
    class App
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();

            list1.Add(2);
            list1.Add(3);
            list1.Add(12);
            list1.Add(120);
            list1.Add(1);
            list1.Add(15);
            list1.Add(45);
            list1.Add(456);

            list2 = list1.Copy();

            Console.WriteLine(list2);
        }
    }
}
