using System.Collections.Generic;
using ShapesTask.Shapes;

namespace ShapesTask.Utils
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter().CompareTo(shape2.GetPerimeter()) > 0)
            {
                return 1;
            }

            if (shape1.GetPerimeter().CompareTo(shape2.GetPerimeter()) < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}
