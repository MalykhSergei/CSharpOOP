using System;

namespace ArrayListTask
{
    class App
    {
        static void Main(string[] args)
        {
            ArrayList<int> list1 = new ArrayList<int>();

            list1.Add(35);
            list1.Add(3);
            list1.Add(350);

            Console.WriteLine(list1);
        }
    }
}
