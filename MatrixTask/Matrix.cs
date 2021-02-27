using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private readonly Vector[] rows;

        public int GetRowsCount
        {
            get
            {
                return rows.Length;
            }
        }

        public int GetColumnsCount
        {
            get
            {
                return rows[0].Size;
            }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Number of rows = {rowsCount}. It must be greater than 0", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Number of columns = {columnsCount}. It must be greater than 0", nameof(columnsCount));
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
            if (components.GetLength(0) == 0 || components.GetLength(1) == 0)
            {
                throw new ArgumentException("The Matrix size must be greater than 0");
            }

            rows = new Vector[components.GetLength(0)];

            Vector vector = new Vector(new double[components.GetLength(1)]);

            for (int i = 0; i < components.GetLength(0); i++)
            {
                for (int j = 0; j < components.GetLength(1); j++)
                {
                    vector[j] = components[i, j];
                }

                Vector vectorCopy = new Vector(vector);

                rows[i] = vectorCopy;
            }
        }

        public Matrix(Vector[] vectors)
        {
            int length = vectors.Length;

            rows = new Vector[length];

            for (int i = 0; i < length; i++)
            {
                rows[i] = new Vector(vectors[i]);
            }

            foreach (Vector vector in vectors)
            {
                if (rows[0].Size != vector.Size)
                {
                    throw new ArgumentException($"The number of columns - {rows[0].Size} " +
                        $"not equal to the length of the larger vector - {vector.Size} ");
                }
            }
        }

        private void PrintIncorrectArgumentException(int index, int size)
        {
            throw new ArgumentException($"Index i = {index}. The index must be in the range [0, {size})", nameof(index));
        }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                if (rowIndex < 0 || rowIndex >= rows.Length)
                {
                    PrintIncorrectArgumentException(rowIndex, rows.Length);
                }

                if (columnIndex < 0 || columnIndex >= rows[0].Size)
                {
                    PrintIncorrectArgumentException(columnIndex, rows[0].Size);
                }

                return rows[rowIndex][columnIndex];
            }
            set
            {
                if (rowIndex < 0 || rowIndex >= rows.Length)
                {
                    PrintIncorrectArgumentException(rowIndex, rows.Length);
                }

                if (columnIndex < 0 || columnIndex >= rows[0].Size)
                {
                    PrintIncorrectArgumentException(columnIndex, rows[0].Size);
                }

                rows[rowIndex][columnIndex] = value;
            }
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                PrintIncorrectArgumentException(index, rows.Length);
            }

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            int vectorLength = vector.Size;
            int matrixLength = rows.Length;

            if (vectorLength != rows[0].Size)
            {
                throw new ArgumentException($"The length of the vector = {vectorLength} must match the length of the matrix row = {matrixLength}!");
            }

            if (index < 0 || index >= matrixLength)
            {
                PrintIncorrectArgumentException(index, matrixLength);
            }

            rows[index] = vector;
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= rows[0].Size)
            {
                PrintIncorrectArgumentException(index, rows[0].Size);
            }

            double[] array = new double[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i][index];
            }

            return new Vector(array);
        }

        public Matrix Transpose()
        {
            Matrix transposedMatrix = new Matrix(new double[rows[0].Size, rows.Length]);

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[0].Size; j++)
                {
                    transposedMatrix[j, i] = rows[i][j];
                }
            }

            return transposedMatrix;
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
            if (rows.Length != rows[0].Size)
            {
                throw new InvalidOperationException("There must be a square matrix!");
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
            double determinant = 0;
            int length = array.GetLength(0);

            if (length == 1)
            {
                return array[0, 0];
            }

            if (length == 2)
            {
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            }

            for (int i = 0; i < length; i++)
            {
                determinant += array[0, i] * Math.Pow(-1, i) * CalculateDeterminant(GetMinor(array, i));
            }

            return determinant;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            int vectorLength = vector.Size;

            if (vectorLength != rows[0].Size)
            {
                throw new ArgumentException("The dimension of the vector must match the number of columns in the matrix");
            }

            Vector result = new Vector(new double[rows.Length]);

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = Vector.GetScalarProduct(rows[i], vector);
            }

            return result;
        }

        private void PrintIncorrectSizeMatricesException(int rowsCount1, int columnsCount1, int rowsCount2, int columnsCount2)
        {
            throw new ArgumentException($"The dimension of the matrices must be the same. Matrix1 = [{rowsCount1}, {columnsCount1}], " +
                     $"Matrix2 = [{rowsCount2}, {columnsCount2}");
        }

        public void Add(Matrix matrix)
        {
            int rowsCount = rows.Length;
            int columnsCount = rows[0].Size;

            if ((rowsCount != matrix.rows.Length) || (columnsCount != matrix.rows[0].Size))
            {
                PrintIncorrectSizeMatricesException(rowsCount, columnsCount, matrix.rows.Length, matrix.rows[0].Size);
            }

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int rowsCount = rows.Length;
            int columnsCount = rows[0].Size;

            if ((rowsCount != matrix.rows.Length) || (columnsCount != matrix.rows[0].Size))
            {
                PrintIncorrectSizeMatricesException(rowsCount, columnsCount, matrix.rows.Length, matrix.rows[0].Size);
            }

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.rows.Length, matrix2.rows[0].Size);

            for (int i = 0; i < matrix1.rows.Length; i++)
            {
                for (int j = 0; j < matrix2.rows[0].Size; j++)
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
            return rows.Equals(obj);
        }

        public override int GetHashCode()
        {
            return rows.GetHashCode();
        }
    }
}
