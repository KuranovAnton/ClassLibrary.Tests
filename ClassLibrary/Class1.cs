namespace ClassLibrary
{
    using System;

    public class Matrix
    {
        private double[,] data;

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов должно быть больше нуля.");
            }

            data = new double[rows, columns];
        }

        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Матрица не может быть null.");
            }

            data = array;
        }

        public int Rows
        {
            get { return data.GetLength(0); }
        }

        public int Columns
        {
            get { return data.GetLength(1); }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                {
                    throw new IndexOutOfRangeException("Индексы находятся вне диапазона матрицы.");
                }
                return data[row, column];
            }
            set
            {
                if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                {
                    throw new IndexOutOfRangeException("Индексы находятся вне диапазона матрицы.");
                }
                data[row, column] = value;
            }
        }

        public double SumOfSquaresGreaterThan(double threshold)
        {
            double sum = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (data[i, j] > threshold)
                    {
                        sum += data[i, j] * data[i, j];
                    }
                }
            }
            return sum;
        }

        public double SumOfSquaresAfter(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new IndexOutOfRangeException("Индексы находятся вне диапазона матрицы.");
            }

            double sum = 0;
            for (int i = row; i < Rows; i++)
            {
                for (int j = (i == row) ? column + 1 : 0; j < Columns; j++)
                {
                    sum += data[i, j] * data[i, j];
                }
            }
            return sum;
        }
    }

}
