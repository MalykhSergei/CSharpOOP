namespace ShapesTask.Shapes
{
    class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double GetWidth()
        {
            return Side;
        }

        public double GetHeight()
        {
            return Side;
        }

        public double GetPerimeter()
        {
            return 4 * Side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной {Side}";
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

            Square square = (Square)obj;

            return Side == square.Side;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Side.GetHashCode();

            return hash;
        }
    }
}
