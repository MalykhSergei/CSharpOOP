using System;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int length)
        {
            if (length <= 0)
            {
                string message = $"Length = {length}. It must be greater than 0!";
                throw new ArgumentException(message, nameof(length));
            }

            components = new double[length];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.components.Length];
            vector.components.CopyTo(components, 0);
        }

        public Vector(double[] components)
        {
            if (components.Length <= 0)
            {
                string message = $"Length = {components.Length}. It must be greater than 0!";
                throw new ArgumentException(message, nameof(components.Length));
            }

            this.components = new double[components.Length];

            components.CopyTo(this.components, 0);
        }

        public Vector(int length, double[] components)
        {
            if (length <= 0)
            {
                string message = $"Length = {length}. It must be greater than 0!";
                throw new ArgumentException(message, nameof(length));
            }

            this.components = new double[length];

            components.CopyTo(this.components, 0);
        }

        public int GetSize()
        {
            return components.Length;
        }

        public double this[int index]
        {
            get
            {
                if (index >= GetSize() || index < 0)
                {
                    string message = $"Index = {index}. It must be greater than or equal to 0 and less {GetSize()}";
                    throw new ArgumentOutOfRangeException(message, nameof(index));
                }

                return components[index];
            }
            set
            {
                if (index >= GetSize() || index < 0)
                {
                    string message = $"Index = {index}. It must be greater than or equal to 0 and less {GetSize()}";
                    throw new ArgumentOutOfRangeException(message, nameof(index));
                }

                components[index] = value;
            }
        }

        public void Add(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector[i];
            }
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double e in components)
            {
                sum += e * e;
            }

            return Math.Sqrt(sum);
        }

        //public double GetElement(int index)
        //{
        //    return components[index];
        //}

        //public void SetElement(int index, double value)
        //{
        //    components[index] = value;
        //}

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);

            result.Add(vector2);

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);

            result.Subtract(vector2);

            return result;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minLength = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalarProduct = 0;

            for (int i = 0; i < minLength; i++)
            {
                scalarProduct += vector1[i] * vector2[i];
            }

            return scalarProduct;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append(components[0]);

            for (int i = 1; i < components.Length; i++)
            {
                sb.Append(", ");
                sb.Append(components[i]);
            }

            sb.Append("}");

            return sb.ToString();
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

            Vector vector = (Vector)obj;
          
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double element in components)
            {
                hash = prime * hash + element.GetHashCode();
            }

            return hash;
        }
    }
}