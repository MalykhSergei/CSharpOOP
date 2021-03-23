using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayListHomeTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"Читаем в список строки из файла: {string.Join(", ", Utils.GetStringsListFromFile("1.txt"))}");
            Console.WriteLine();

            List<int> numbers = new List<int> { 1, 2, 3, 2, 2, 2, 3, 4, 4, 4, 4, 4, 5, 5 };

            Utils.RemoveEvenNumbers(numbers);

            Console.WriteLine($"Список нечетных чисел: {string.Join(", ", numbers)}");
            Console.WriteLine();

            List<int> listWithDuplicates = new List<int> { 1, 2, 3, 3, 4, 5, 5, 5, 6 };

            Console.WriteLine($"Список без повторяющихся элементов: {string.Join(", ", Utils.GetItemsListWithoutDuplicates(listWithDuplicates))}");

            Console.ReadKey();
        }
    }
}
