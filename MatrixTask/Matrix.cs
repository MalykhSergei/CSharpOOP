using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        private Vector[] rows;

        public int RowsCount => rows.Length;

        public int ColumnsCount => rows[0].Size;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowsCount), $"{nameof(rowsCount)} = {rowsCount}. It must be greater than 0");
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnsCount), $"{nameof(columnsCount)} = {columnsCount}. It must be greater than 0");
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
            int rowsCount = components.GetLength(0);
            int columnsCount = components.GetLength(1);

            if (rowsCount == 0 || columnsCount == 0)
            {
                throw new ArgumentException($"{nameof(components)} = 0. It must be greater than 0", nameof(components));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    rows[i][j] = components[i, j];
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException(nameof(vectors), "Array is empty");
            }

            int maxSize = vectors[0].Size;

            for (int i = 1; i < vectors.Length; i++)
            {
                maxSize = Math.Max(maxSize, vectors[i].Size);
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Size < maxSize)
                {
                    rows[i] = new Vector(maxSize);
                    rows[i].Add(vectors[i]);
                }
                else
                {
                    rows[i] = new Vector(vectors[i]);
                }
            }
        }

        private static void CheckIndex(int index, int upperBound)
        {
            if (index < 0 || index >= upperBound)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be greater than or equal to 0 and less than {upperBound}");
            }
        }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                CheckIndex(rowIndex, rows.Length);
                CheckIndex(columnIndex, ColumnsCount);

                return rows[rowIndex][columnIndex];
            }
            set
            {
                CheckIndex(rowIndex, rows.Length);
                CheckIndex(columnIndex, ColumnsCount);

                rows[rowIndex][columnIndex] = value;
            }
        }

        public Vector GetRow(int index)
        {
            CheckIndex(index, rows.Length);

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if (vector.Size != ColumnsCount)
            {
                throw new ArgumentException($"The size of the vector = {vector.Size} must match the length of the matrix row = {ColumnsCount}!", nameof(vector));
            }

            CheckIndex(index, rows.Length);

            rows[index] = vector;
        }

        public Vector GetColumn(int index)
        {
            CheckIndex(index, ColumnsCount);

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
                throw new ArgumentException($"The dimension of the vector = {vector.Size} must match the number of columns in the matrix = {ColumnsCount}", nameof(vector));
            }

            Vector result = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = Vector.GetScalarProduct(rows[i], vector);
            }

            return result;
        }

        private static void CheckMatricesDimensions(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException($"{nameof(matrix1)} = [{matrix1.RowsCount}, {matrix1.ColumnsCount}]. {nameof(matrix2)} = [{matrix2.RowsCount}, {matrix2.ColumnsCount}]." +
                $" The dimension of the matrices must be the same");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckMatricesDimensions(this, matrix);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckMatricesDimensions(this, matrix);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            CheckMatricesDimensions(matrix1, matrix2);

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            CheckMatricesDimensions(matrix1, matrix2);

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Matrix1 {nameof(matrix1.ColumnsCount)} = {matrix1.ColumnsCount}, Matrix2 {nameof(matrix2.RowsCount)} = {matrix2.RowsCount}. The matrices are not consistent");
            }

            Matrix result = new Matrix(matrix1.rows.Length, matrix2.ColumnsCount);

            for (int i = 0; i < matrix1.rows.Length; i++)
            {
                for (int j = 0; j < matrix2.ColumnsCount; j++)
                {
                    result[i, j] = Vector.GetScalarProduct(matrix1.rows[i], matrix2.GetColumn(j));
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
    }
}