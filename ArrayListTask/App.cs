using System;

namespace ArrayListTask
{
    class App
    {
        static void Main(string[] args)
        {
            ArrayList<string> list = new ArrayList<string>();

            list.Add("one");
            list.Add("two");
            list.Add(null);
            list.Add("four");

            Console.WriteLine(list);
        }
    }
}
