using System;
using System.Text;

namespace RangeTask
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Range range1 = new Range(1, 5); 
            Range range2 = new Range(3, 15);

            Range intersection = range1.GetIntersection(range2);

            Console.WriteLine("Интервал пересечения равен: ");

            if (intersection == null)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine(intersection);
            }

            Console.WriteLine();

            Range[] union = range1.GetUnion(range2);

            Console.WriteLine("Интервал обьединения равен: ");
            Range.Print(union);

            Console.WriteLine();

            Range[] difference = range1.GetDifference(range2);

            Console.WriteLine("Разность интервалов равна: ");
            Range.Print(difference);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
