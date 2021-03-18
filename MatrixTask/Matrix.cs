using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public int RowsCount => rows.Length;

        public int ColumnsCount => rows[0].Size;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Number of rows = {rowsCount}. It must be greater than 0", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Number of columns = {columnsCount}. It must be greater than 0", nameof(columnsCount));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix) : this(matrix.rows)
        {

        }

        public Matrix(double[,] components)
        {
            if (components.GetLength(0) <= 0 || components.GetLength(1) <= 0)
            {
                throw new ArgumentOutOfRangeException("The Matrix size must be greater than 0");
            }

            rows = new Vector[components.GetLength(0)];

            for (int i = 0; i < components.GetLength(0); i++)
            {
                rows[i] = new Vector(components.GetLength(1));

                for (int j = 0; j < components.GetLength(1); j++)
                {
                    rows[i][j] = components[i, j];
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            int maximum = vectors[0].Size;

            for (int i = 1; i < vectors.Length; i++)
            {
                maximum = Math.Max(maximum, vectors[i].Size);
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Size < maximum)
                {
                    rows[i] = new Vector(maximum);
                    rows[i].Add(vectors[i]);
                }
                else
                {
                    rows[i] = new Vector(vectors[i]);
                }
            }
        }

        private static void CheckArguments(int arg1, int arg2)
        {
            if (arg1 < 0 || arg1 >= arg2)
            {
                throw new ArgumentOutOfRangeException(nameof(arg1), $"Index must be less than 0 and greater than or equal to {arg2}");
            }
        }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                CheckArguments(rowIndex, rows.Length);
                CheckArguments(columnIndex, ColumnsCount);

                return rows[rowIndex][columnIndex];
            }
            set
            {
                CheckArguments(rowIndex, rows.Length);
                CheckArguments(columnIndex, ColumnsCount);

                rows[rowIndex][columnIndex] = value;
            }
        }

        public Vector GetRow(int index)
        {
            CheckArguments(index, rows.Length);

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if (vector.Size != ColumnsCount)
            {
                throw new ArgumentException($"The size of the vector = {vector.Size} must match the length of the matrix row = {rows.Length}!");
            }

            CheckArguments(index, rows.Length);

            rows[index] = vector;
        }

        public Vector GetColumn(int index)
        {
            CheckArguments(index, ColumnsCount);

            double[] array = new double[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i][index];
            }

            return new Vector(array);
        }

        public void Transpose()
        {
            var resultRows = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                resultRows[i] = GetColumn(i);
            }

            rows = resultRows;
        }

        public void MultiplyByScalar(double number)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(number);
            }
        }

        public double GetDeterminant()
        {
            if (rows.Length != ColumnsCount)
            {
                throw new InvalidOperationException($"Width = {ColumnsCount}, height = {rows.Length}. There must be a square matrix!");
            }

            int length = rows.Length;
            double[,] array = new double[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return CalculateDeterminant(array);
        }

        private static double[,] GetMinor(double[,] array, int index)
        {
            int length = array.GetLength(0);
            double[,] minor = new double[length - 1, length - 1];

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (j < index)
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
            int length = array.GetLength(0);

            if (length == 1)
            {
                return array[0, 0];
            }

            if (length == 2)
            {
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            }

            double determinant = 0;

            for (int i = 0; i < length; i++)
            {
                determinant += array[0, i] * Math.Pow(-1, i) * CalculateDeterminant(GetMinor(array, i));
            }

            return determinant;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector.Size != ColumnsCount)
            {
                throw new ArgumentException($"The dimension of the vector ({vector.Size}) must match the number of columns ({ColumnsCount}) in the matrix");
            }

            Vector result = new Vector(new double[rows.Length]);

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = Vector.GetScalarProduct(rows[i], vector);
            }

            return result;
        }

        private static void CheckMatricesSize(int rowsCount1, int columnsCount1, int rowsCount2, int columnsCount2)
        {
            if ((rowsCount1 != rowsCount2) || (columnsCount1 != columnsCount2))
            {
                throw new ArgumentException($"The dimension of the matrices must be the same. Matrix1 = [{rowsCount1}, {columnsCount1}], " +
                     $"Matrix2 = [{rowsCount2}, {columnsCount2}");
            }
        }

        public void Add(Matrix matrix)
        {
            int rowsCount = rows.Length;

            CheckMatricesSize(rowsCount, ColumnsCount, matrix.rows.Length, matrix.ColumnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int rowsCount = rows.Length;

            CheckMatricesSize(rowsCount, ColumnsCount, matrix.rows.Length, matrix.ColumnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            CheckMatricesSize(matrix1.RowsCount, matrix1.ColumnsCount, matrix2.RowsCount, matrix2.ColumnsCount);

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            CheckMatricesSize(matrix1.RowsCount, matrix1.ColumnsCount, matrix2.RowsCount, matrix2.ColumnsCount);

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException("The matrices are not consistent");
            }

            Matrix result = new Matrix(matrix1.rows.Length, matrix2.ColumnsCount);

            for (int i = 0; i < matrix1.rows.Length; i++)
            {
                for (int j = 0; j < matrix2.ColumnsCount; j++)
                {
                    result[i, j] += Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j));
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append(rows[0]);

            for (int i = 1; i < rows.Length; i++)
            {
                sb.Append(", ");
                sb.Append(rows[i]);
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

            return Equals(rows, matrix.rows);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + rows.GetHashCode();

            return hash;
        }
    }
}
