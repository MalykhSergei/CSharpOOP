using System.Collections.Generic;
using ShapesTask.Shapes;

namespace ShapesTask.Utils
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea().CompareTo(shape2.GetArea()) > 0)
            {
                return 1;
            }

            if (shape1.GetArea().CompareTo(shape2.GetArea()) < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}
