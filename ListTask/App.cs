using System;

namespace ListTask
{
    class App
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();

            list1.Add(1);
            list1.AddFirstElement(10);

            Console.WriteLine(list1);
        }
    }
}
