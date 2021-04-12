using System;

namespace ArrayListTask
{
    class App
    {
        static void Main(string[] args)
        {
            ArrayList<int> list1 = new ArrayList<int>();

            list1.Add(1);
            list1.Add(23);
            list1.Add(12);

            Console.WriteLine(list1);
        }
    }
}
