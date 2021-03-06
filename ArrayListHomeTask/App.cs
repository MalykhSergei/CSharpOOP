using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListHomeTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Utils.ReadFile("1.txt")));

            Console.WriteLine();

            List<int> list = new List<int>() { 1, 2, 3, 4, 4, 4, 4, 4, 5, 5 };

            Utils.RemoveEvenNumbers(list);

            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine(string.Join(", ", Utils.RemoveDuplicateItems(list)));
        }
    }
}
