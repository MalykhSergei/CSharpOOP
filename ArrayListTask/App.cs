using System;

namespace ArrayListTask
{
    class App
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>()
            {
                5,
                10,
                15,
                20
            };

            list.Remove(20);

            Console.WriteLine(list);
        }
    }
}
