using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsNumber, int columnsNumber)
        {
            if (rowsNumber <= 0)
            {
                throw new ArgumentException("Количество строк должно быть больше нуля!");
            }

            if (columnsNumber <= 0)
            {
                throw new ArgumentException("Количество столбцов должно быть больше нуля!");
            }

            rows = new Vector[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i] = new Vector(columnsNumber);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = matrix.rows;
        }

        public Matrix(double[,] components)
        {
            rows = new Vector[components.GetLength(0)];

            for (int i = 0; i < components.GetLength(0); i++)
            {
                double[] array = new double[components.GetLength(1)];

                for (int j = 0; j < components.GetLength(1); j++)
                {
                    array[j] = components[i, j];
                }

                Vector vector = new Vector(array);

                rows[i] = vector;
            }
        }

        public Matrix(Vector[] vectors)
        {
            int length = vectors.Length;

            foreach (Vector vector in vectors)
            {
                if (vector.GetSize() != vectors[0].GetSize())
                {
                    throw new ArgumentException("Все векторы массива должны быть одной длины");
                }
            }

            rows = new Vector[length];

            for (int i = 0; i < length; i++)
            {
                Vector vector = new Vector(vectors[i]);
                rows[i] = vector;
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= this.GetNumberRows())
                {
                    throw new ArgumentOutOfRangeException("Индекс i больше количества строк");
                }

                if (j >= this.GetNumberColumns())
                {
                    throw new ArgumentOutOfRangeException("Индекс j больше количества столбцов");
                }

                return rows[i][j];
            }
            set
            {
                if (i >= this.GetNumberRows())
                {
                    throw new ArgumentOutOfRangeException("Индекс i больше количества строк");
                }

                if (j >= this.GetNumberColumns())
                {
                    throw new ArgumentOutOfRangeException("Индекс j больше количества столбцов");
                }

                rows[i][j] = value;
            }
        }

        public int GetNumberRows()
        {
            return rows.Length;
        }

        public int GetNumberColumns()
        {
            return rows[0].GetSize();
        }

        public Vector GetVectorRow(int index)
        {
            if (index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Неверный индекс вектора-строки!");
            }

            return new Vector(rows[index]);
        }

        public void SetVectorRow(int index, Vector vector)
        {
            int lengthVector = vector.GetSize();
            int lengthMatrix = rows.Length;

            if (lengthVector != rows[0].GetSize())
            {
                throw new ArgumentException("Вектор должен совпадать по размеру с длиной строки матрицы!");
            }

            if (index > lengthMatrix - 1)
            {
                throw new IndexOutOfRangeException("Неверный индекс вектора-строки!");
            }

            rows[index] = vector;
        }

        public Vector GetVectorColumn(int index)
        {
            if (index >= rows[0].GetSize())
            {
                throw new ArgumentOutOfRangeException("Индекс не может быть больше длины вектора");
            }

            double[] array = new double[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i].GetElement(index);
            }

            return new Vector(array);
        }

        public void Transposition()
        {
            for (int i = 0; i < this.GetNumberColumns(); i++)
            {
                rows[i] = GetVectorColumn(i);
            }
        }

        public void MultiplyScalar(double number)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyScalar(number);
            }
        }

        public double GetDeterminant()
        {
            if (rows.Length != rows[0].GetSize())
            {
                throw new InvalidOperationException("Необходима квадратная матрица для расчета определителя!");
            }

            int length = rows.Length;
            double[,] array = new double[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = rows[i].GetElement(j);
                }
            }

            return CalculateDeterminant(array);
        }

        private static double[,] GetMinor(double[,] array, int elementMinor)
        {
            int length = array.GetLength(0);
            double[,] minor = new double[length - 1, length - 1];

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (j < elementMinor)
                    {
                        minor[i, j] = array[i + 1, j];
                    }
                    else
                    {
                        minor[i, j] = array[i + 1, j + 1];
                    }
                }
            }

            return minor;
        }

        private static double CalculateDeterminant(double[,] array)
        {
            double determinant = 0;
            int length = array.GetLength(0);

            if (length == 2)
            {
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            }

            if (length == 1)
            {
                return array[0, 0];
            }

            for (int i = 0; i < length; i++)
            {
                determinant += array[0, i] * Math.Pow(-1, i) * CalculateDeterminant(GetMinor(array, i));
            }

            return determinant;
        }

        public Vector MultiplyVector(Vector vector)
        {
            int lengthVector = vector.GetSize();

            if (lengthVector != rows[0].GetSize())
            {
                throw new ArgumentException("Размерность вектора должна совпадать с количеством столбцов матрицы!");
            }

            int length = rows.Length;
            double[] array = new double[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = Vector.GetScalarMultiplication(rows[i], vector);
            }

            return new Vector(array);
        }

        public void Add(Matrix matrix)
        {
            int length = rows.Length;
            int lengthRow = rows[0].GetSize();

            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("Размерность матриц должна быть одинаковая");
            }

            for (int i = 0; i < length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int length = rows.Length;
            int lengthRow = rows[0].GetSize();

            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("Размерность матриц должна быть одинаковая");
            }

            for (int i = 0; i < length; i++)
            {
                rows[i].Substract(matrix.rows[i]);
            }
        }

        public static Matrix GetMatrixAddition(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);

            matrixCopy.Add(matrix2);

            return matrixCopy;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);

            matrixCopy.Subtract(matrix2);

            return matrixCopy;
        }

        public Matrix Multiply(Matrix matrix)
        {
            int length = rows.Length;
            int countColumns = rows[0].GetSize();
            int lengthMatrix = matrix.GetNumberRows();
            int countColumnsMatrix = matrix.GetNumberColumns();

            if (countColumns != lengthMatrix)
            {
                throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк во второй");
            }

            double[,] multiplyArray = new double[length, countColumnsMatrix];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < countColumnsMatrix; j++)
                {
                    double sum = 0;

                    for (int r = 0; r < countColumns; r++)
                    {
                        sum += rows[i].GetElement(r) * matrix.rows[r].GetElement(j);
                    }

                    multiplyArray[i, j] = sum;
                }
            }

            return new Matrix(multiplyArray);
        }

        public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Multiply(matrix2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{{");
            sb.Append(rows[0].GetElement(0));

            for (int i = 1; i < rows[0].GetSize(); i++)
            {
                sb.Append(", ");
                sb.Append(rows[0].GetElement(i));
            }

            sb.Append("}");

            for (int i = 1; i < rows.Length; i++)
            {
                sb.Append(", {");
                sb.Append(rows[i].GetElement(0));

                for (int j = 1; j < rows[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(rows[i].GetElement(j));
                }

                sb.Append("}");
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

            Matrix matrix = (Matrix)obj;

            if ((matrix.GetNumberColumns() != GetNumberColumns()) || (matrix.GetNumberRows() != GetNumberRows()))
            {
                return false;
            }

            for (int i = 0; i < matrix.GetNumberRows(); i++)
            {
                for (int j = 0; j < matrix.GetNumberColumns(); j++)
                {
                    if (matrix[j, i] != this[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < GetNumberRows(); i++)
            {
                for (int j = 0; j < GetNumberColumns(); j++)
                {
                    hash = prime * hash * (int)this[i, j];
                }
            }

            return hash;
        }
    }
}
