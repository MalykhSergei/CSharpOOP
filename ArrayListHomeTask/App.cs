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
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"Читаем в список строки из файла: {string.Join(", ", Utils.GetStringsFromFileList("1.txt"))}");

            Console.WriteLine();

            List<int> list = new List<int> { 1, 2, 3, 2, 2, 2, 3, 4, 4, 4, 4, 4, 5, 5 };

            Utils.RemoveEvenNumbers(list);

            Console.WriteLine($"Список без четных элементов: { string.Join(", ", list)}");

            Console.WriteLine();

            Console.WriteLine($"Список без повторяющихся элементов: { string.Join(", ", Utils.GetWithoutDuplicateItemsList(list))}");

            Console.ReadKey();
        }
    }
}
