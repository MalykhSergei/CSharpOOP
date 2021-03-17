using System;
using System.Collections.Generic;

namespace ArrayListTask
{
    class App
    {
        static void Main(string[] args)
        {
            ArrayList<int> list1 = new ArrayList<int>();

            list1.Add(1);
            list1.Add(2);
            list1.Add(3);

            Console.WriteLine(list1);
        }
    }
}
