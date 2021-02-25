using System;
using ShapesTask.Shapes;

namespace ShapesTask.Utils
{
    class Utils
    {
        public static IShape GetShapeWithMaxArea(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                throw new ArgumentException("Array is empty!", nameof(shapes.Length));
            }

            Array.Sort(shapes, new AreaComparer());

            return shapes[shapes.Length - 1];
        }

        public static IShape GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                throw new ArgumentException("Array is empty!", nameof(shapes.Length));
            }

            if (shapes.Length < 2)
            {
                throw new ArgumentException("There are less than two shapes in the array!", nameof(shapes.Length));
            }

            Array.Sort(shapes, new PerimeterComparer());

            return shapes[shapes.Length - 2];
        }
    }
}
