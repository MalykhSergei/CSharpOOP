using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Person> persons = new List<Person>
            {
                new Person("John", 25),
                new Person("Stefani", 34),
                new Person("Laura", 15),
                new Person("Clark", 29),
                new Person("John", 34),
                new Person("John", 17),
                new Person("Petra", 21),
                new Person("Kevin", 10),
                new Person("John", 32)
            };

            var uniqueNames = string.Join(", ", persons
                .Select(x => x.Name)
                .Distinct()
                .ToList());

            Console.WriteLine($"Список уникальных имен: {uniqueNames}");

            Console.WriteLine();

            var under18YearsAgePeopleList = string.Join(", ", persons
                .Where(x => x.Age < 18)
                .Select(x => x.Age)
                .Average());

            Console.WriteLine($"Средний возраст людей младше 18 лет: {under18YearsAgePeopleList}");

            Console.WriteLine();

            var averageAgePeople = persons
                .GroupBy(x => x.Name, x => x.Age)
                .ToDictionary(x => x.Key, x => x
                .Average());

            Console.WriteLine("Map: ");

            foreach (var item in averageAgePeople)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine();

            var from20To45YearsAgePeople = string.Join(", ", persons
                .Where(x => x.Age >= 20 && x.Age <= 45)
                .OrderByDescending(x => x.Age)
                .Select(x => x.Name));

            Console.WriteLine($"Люди в возрасте от 20 до 45 лет: {from20To45YearsAgePeople}");

            Console.WriteLine();

            Console.WriteLine("Введите количество элементов для вычисления: ");
            int userNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Бесконечный поток корней чисел: ");

            foreach (var item in Utils.GetSquareRootsNumbersStream(userNumber))
            {
                Console.WriteLine("{0:f2}", item);
            }

            Console.WriteLine();

            Console.WriteLine("Бесконечный поток чисел Фибоначчи: ");

            foreach (var item in Utils.GetFibbonacciNumbers(userNumber))
            {
                Console.WriteLine(item);
            }
        }
    }
}
