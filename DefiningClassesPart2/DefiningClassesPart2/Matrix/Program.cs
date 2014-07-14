using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Matrix<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            T type = default(T);
            if (!((type is double) || (type is int) || (type is decimal)))
            {
                throw new ApplicationException("T must be (double, int or decimal)");
            }
            else
            {
                this.rows = rows;
                this.cols = cols;
                this.matrix = new T[rows, cols];
            }
        }

        public T this[int row, int col]
        {
            get
            {
                CheckMatrixRange(row, col);
                return this.matrix[row, col];
            }
            set
            {
                CheckMatrixRange(row, col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if ((first.rows != second.rows) || (first.cols != second.cols))
            {
                throw new ApplicationException("Matrices must have same sizes");
            }
            Matrix<T> resultMatrix = new Matrix<T>(first.rows, first.cols);
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < first.cols; j++)
                {
                    resultMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if ((first.rows != second.rows) || (first.cols != second.cols))
            {
                throw new ApplicationException("Matrices must have same sizes");
            }
            Matrix<T> resultMatrix = new Matrix<T>(first.rows, first.cols);
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < first.cols; j++)
                {
                    resultMatrix[i, j] = (dynamic)first[i, j] - second[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.cols != second.rows)
            {
                throw new ApplicationException("Matrices must have same sizes");
            }

            Matrix<T> resultMatrix = new Matrix<T>(first.rows, second.cols);
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < second.cols; j++)
                {
                    for (int k = 0; k < first.cols; k++)
                    {
                        resultMatrix[i, j] += (dynamic)first[i, k] * second[k, j];
                    }
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i,j] != default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i, j] != default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CheckMatrixRange(int row, int col)
        {
            if ((row < 0) || (row >= this.rows) || (col < 0) || (col >= this.cols))
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            Matrix<double> matrix = new Matrix<double>(1, 3);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("[{0},{1}] -> ", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                    counter++;
                }
            }
            counter = 0;
            Matrix<double> matrix1 = new Matrix<double>(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("[{0},{1}] -> ", i, j);
                    matrix1[i, j] = double.Parse(Console.ReadLine());
                    counter++;
                }
            }

            Matrix<double> newMatrix = matrix * matrix1;
            Console.WriteLine("\n");
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(newMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
