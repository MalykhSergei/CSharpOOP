using System;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше 0!");
            }

            components = new double[n];
        }

        public Vector(Vector vector)
        {
            components = vector.components;
        }

        public Vector(double[] components)
        {
            this.components = new double[components.Length];

            components.CopyTo(this.components, 0);
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше 0!");
            }

            this.components = new double[n];

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
                if (index >= GetSize())
                {
                    throw new ArgumentOutOfRangeException("Слишком большой индекс");
                }
                return components[index];
            }
            set
            {
                if (index >= GetSize())
                {
                    throw new ArgumentOutOfRangeException("Слишком большой индекс");
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
                components[i] += vector.components[i];
            }
        }

        public void Substract(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyScalar(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double e in components)
            {
                sum += Math.Pow(e, 2);
            }

            return Math.Sqrt(sum);
        }

        public double GetElement(int index)
        {
            return components[index];
        }

        public void SetElement(int index, double value)
        {
            components[index] = value;
        }

        public static Vector GetVektorAddition(Vector vector1, Vector vector2)
        {
            Vector vector3 = new Vector(vector1);

            vector3.Add(vector2);

            return vector3;
        }

        public static Vector GetVektorDifference(Vector vector1, Vector vector2)
        {
            Vector vector3 = new Vector(vector1);

            vector3.Substract(vector2);

            return vector3;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int min = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalar = 0;

            for (int i = 0; i < min; i++)
            {
                scalar += vector1.components[i] * vector2.components[i];
            }

            return scalar;
        }

        public override string ToString()
        {
            return string.Join(", ", components);
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
                if (components[i] != vector.components[i])
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

            for (int i = 0; i < components.Length; i++)
            {
                hash = (int)(prime * hash + components[i]);
            }

            return hash;
        }
    }
}