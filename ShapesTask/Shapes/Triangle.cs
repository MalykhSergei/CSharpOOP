using System;

namespace ShapesTask.Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        private double GetSideALength()
        {
            return GetDistance(X1, Y1, X2, Y2);
        }

        private double GetSideBLength()
        {
            return GetDistance(X2, Y2, X3, Y3);
        }

        private double GetSideCLength()
        {
            return GetDistance(X1, Y1, X3, Y3);
        }

        public double GetArea()
        {
            double getSideALength = GetSideALength();
            double getSideBLength = GetSideBLength();
            double getSideCLength = GetSideCLength();

            double semiPerimeter = (getSideALength + getSideBLength + getSideCLength) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - getSideALength) * (semiPerimeter - getSideBLength) * (semiPerimeter - getSideCLength));
        }

        public double GetPerimeter()
        {
            return GetSideALength() + GetSideBLength() + GetSideCLength();
        }

        public override string ToString()
        {
            return $"Треугольник с вершинами: ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3})";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2
                && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 37;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
