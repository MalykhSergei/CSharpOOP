using System;
using System.Text;
using ShapesTask.Shapes;

namespace ShapesTask.Utils
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IShape[] shapes =
            {
                new Square(3),
                new Circle(5),
                new Rectangle(4, 7),
                new Square(7),
                new Rectangle(2, 5),
                new Triangle(3, 4, 5, 8, 9, 6),
                new Circle(3),
                new Rectangle(3, 4)
            };

            Console.WriteLine("Фигура с максимальной площадью: {0}", Utils.GetShapeWithMaxArea(shapes));
            Console.WriteLine();

            Console.WriteLine("Фигура со вторым по величине периметром: {0}", Utils.GetShapeWithSecondPerimeter(shapes));

            Console.ReadKey();
        }
    }
}
