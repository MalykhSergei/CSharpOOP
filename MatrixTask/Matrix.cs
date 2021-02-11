using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private readonly Vector[] rows;

        public Matrix(int rowsNumber, int columnsNumber)
        {
            if (rowsNumber <= 0)
            {
                string message = $"Number of rows = {rowsNumber}. It must be greater than 0";
                throw new ArgumentException(message, nameof(rowsNumber));
            }

            if (columnsNumber <= 0)
            {
                string message = $"Number of columns = {columnsNumber}. It must be greater than 0";
                throw new ArgumentException(message, nameof(columnsNumber));
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
                    string message = $"All array vectors must be of the same length";
                    throw new ArgumentException(message);
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
                if (i >= GetNumberRows())
                {
                    string message = $"Index i = {i}. It must be less than {GetNumberRows()}";
                    throw new ArgumentOutOfRangeException(message, nameof(i));
                }

                if (j >= GetNumberColumns())
                {
                    string message = $"Index j = {j}. It must be less than {GetNumberColumns()}";
                    throw new ArgumentOutOfRangeException(message, nameof(j));
                }

                return rows[i][j];
            }
            set
            {
                if (i >= GetNumberRows())
                {
                    string message = $"Index i = {i}. It must be less than {GetNumberRows()}";
                    throw new ArgumentOutOfRangeException(message, nameof(i));
                }

                if (j >= GetNumberColumns())
                {
                    string message = $"Index j = {j}. It must be less than {GetNumberColumns()}";
                    throw new ArgumentOutOfRangeException(message, nameof(j));
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
                string message = $"Index = {index}. It must be less than {rows.Length}";
                throw new IndexOutOfRangeException(message);
            }

            return new Vector(rows[index]);
        }

        public void SetVectorRow(int index, Vector vector)
        {
            int lengthVector = vector.GetSize();
            int lengthMatrix = rows.Length;

            if (lengthVector != rows[0].GetSize())
            {
                string message = $"The length of the vector must match the length of the matrix row!";
                throw new ArgumentException(message);
            }

            if (index > lengthMatrix - 1)
            {
                string message = $"Index = {index}. It must be less than or equal {lengthMatrix - 1}";
                throw new IndexOutOfRangeException(message);
            }

            rows[index] = vector;
        }

        public Vector GetVectorColumn(int index) //pruf
        {
            if (index >= rows[0].GetSize())
            {
                string message = $"Index = {index}. It must be less than {rows[0].GetSize()}";
                throw new ArgumentOutOfRangeException(message);
            }

            double[] array = new double[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i][index];
            }

            return new Vector(array);
        }

        public void Transposition()
        {
            for (int i = 0; i < GetNumberColumns(); i++)
            {
                rows[i] = GetVectorColumn(i);
            }
        }

        public void MultiplyScalar(double number)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(number);
            }
        }

        public double GetDeterminant()
        {
            if (rows.Length != rows[0].GetSize())
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
                string message = "The dimension of the vector must match the number of columns in the matrix";
                throw new ArgumentException(message);
            }

            int length = rows.Length;
            double[] array = new double[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = Vector.GetScalarProduct(rows[i], vector);
            }

            return new Vector(array);
        }

        public void Add(Matrix matrix)
        {
            int length = rows.Length;
            int lengthRow = rows[0].GetSize();

            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("The dimension of the matrices must be the same");
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
                throw new ArgumentException("The dimension of the matrices must be the same");
            }

            for (int i = 0; i < length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetMatrixAddition(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public Matrix Multiply(Matrix matrix)
        {
            int length = rows.Length;
            int countColumns = rows[0].GetSize();
            int lengthMatrix = matrix.GetNumberRows();
            int countColumnsMatrix = matrix.GetNumberColumns();

            if (countColumns != lengthMatrix)
            {
                string message = "The number of columns in the first matrix must be equal to the number of rows in the second matrix";
                throw new ArgumentException(message);
            }

            double[,] multiplyArray = new double[length, countColumnsMatrix];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < countColumnsMatrix; j++)
                {
                    double sum = 0;

                    for (int r = 0; r < countColumns; r++)
                    {
                        sum += rows[i][r] * matrix.rows[r][j];
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
            sb.Append(rows[0][0]);

            for (int i = 1; i < rows[0].GetSize(); i++)
            {
                sb.Append(", ");
                sb.Append(rows[0][i]);
            }

            sb.Append("}");

            for (int i = 1; i < rows.Length; i++)
            {
                sb.Append(", {");
                sb.Append(rows[i][0]);

                for (int j = 1; j < rows[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(rows[i][j]);
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
                    hash = prime * hash * this[i, j].GetHashCode();
                }
            }

            return hash;
        }
    }
}
