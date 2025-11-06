using ClassLibrary;
using System;
using Xunit;

namespace ClassLibrary.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void Constructor_ValidDimensions_CreatesMatrix()
        {
            int rows = 2;
            int columns = 3;

            Matrix matrix = new Matrix(rows, columns);

            Assert.Equal(rows, matrix.Rows);
            Assert.Equal(columns, matrix.Columns);
        }

        [Fact]
        public void Constructor_ZeroOrNegativeRowsOrColumns_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(0, 3));
            Assert.Throws<ArgumentException>(() => new Matrix(2, 0));
            Assert.Throws<ArgumentException>(() => new Matrix(-1, 5));
            Assert.Throws<ArgumentException>(() => new Matrix(5, -1));
        }

        [Fact]
        public void Constructor_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Matrix(null));
        }

        [Fact]
        public void Indexer_ValidIndices_ReturnsCorrectValue()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            double value = matrix[1, 1];

            Assert.Equal(4.0, value);
        }

        [Fact]
        public void Indexer_OutOfRangeIndices_ThrowsIndexOutOfRangeException()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.Throws<IndexOutOfRangeException>(() => matrix[-1, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[2, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, -1]);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, 2]);
        }

        [Fact]
        public void Indexer_SetValue_UpdatesValue()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            matrix[0, 0] = 10;

            Assert.Equal(10.0, matrix[0, 0]);
            Assert.Equal(2.0, matrix[0, 1]);
        }

        [Fact]
        public void Indexer_SetOutOfRange_ThrowsIndexOutOfRangeException()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.Throws<IndexOutOfRangeException>(() => matrix[2, 0] = 5);
        }

        [Fact]
        public void SumOfSquaresGreaterThan_PositiveThreshold_ReturnsCorrectSum()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double result = matrix.SumOfSquaresGreaterThan(2.0);
            Assert.Equal(25.0, result);
        }

        [Fact]
        public void SumOfSquaresGreaterThan_NegativeThreshold_IncludesAllElements()
        {
            var matrix = new Matrix(new double[,] { { 1, -1 }, { -3, 4 } });
            double result = matrix.SumOfSquaresGreaterThan(-1.0);
            Assert.Equal(17.0, result);
        }

        [Fact]
        public void SumOfSquaresGreaterThan_NoElementsAboveThreshold_ReturnsZero()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double result = matrix.SumOfSquaresGreaterThan(10.0);
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void SumOfSquaresGreaterThan_EmptyMatrix_ReturnsZero()
        {

            var matrix = new Matrix(new double[,] { });
            double result = matrix.SumOfSquaresGreaterThan(2.0);
            Assert.Equal(0.0, result);
        }

        [Theory]
        [InlineData(0.0, 30.0)]
        [InlineData(-4.0, 30.0)]
        public void SumOfSquaresGreaterThan_AllElementsAboveThreshold_ReturnsTotalSum(double el1, double exres)
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double result = matrix.SumOfSquaresGreaterThan(el1);
            Assert.Equal(exres, result);
        }

        [Theory]
        [InlineData(0, 0, 29.0)]
        [InlineData(0, 1, 25.0)]
      
        public void SumOfSquaresAfter_ValidIndices_ReturnsCorrectSum(int row, int col, double expres)
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double result = matrix.SumOfSquaresAfter(row, col);
            Assert.Equal(expres, result);
        }

        [Fact]
        public void SumOfSquaresAfter_LastElement_ReturnsZero()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double result = matrix.SumOfSquaresAfter(1, 1);
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void SumOfSquaresAfter_InvalidIndices_ThrowsException()
        {
            var matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.Throws<IndexOutOfRangeException>(() => matrix.SumOfSquaresAfter(2, 0));
        }

        [Fact]
        public void SumOfSquaresAfter_NoElementsAfter_ReturnsZero()
        {
            var matrix = new Matrix(new double[,] { { 1 }, { 2 } });
            double result = matrix.SumOfSquaresAfter(1, 0);
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void SumOfSquaresAfter_SingleElementMatrix_ReturnsZero()
        {
            var matrix = new Matrix(new double[,] { { 5 } });
            double result = matrix.SumOfSquaresAfter(0, 0);
            Assert.Equal(0.0, result);
        }
    }
}
