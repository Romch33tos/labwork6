using System;

namespace Matrix
{
  public static class MatrixExtensions
  {
    public static SquareMatrix Transpose(this SquareMatrix matrix)
    {
      int size = matrix.MatrixSize;
      int[,] transposed = new int[size, size];

      for (int row = 0; row < size; ++row)
      {
        for (int column = 0; column < size; ++column)
        {
          transposed[column, row] = matrix.MatrixElements[row, column];
        }
      }

      return new SquareMatrix(transposed);
    }

    public static int Trace(this SquareMatrix matrix)
    {
      int trace = 0;
      for (int elementIndex = 0; elementIndex < matrix.MatrixSize; ++elementIndex)
      {
        trace += matrix.MatrixElements[elementIndex, elementIndex];
      }
      
      return trace;
    }

    public delegate SquareMatrix MatrixTransformDelegate(SquareMatrix matrix);

    public static MatrixTransformDelegate Diagonalize = delegate(SquareMatrix matrix)
    {
      int size = matrix.MatrixSize;
      int[,] diagonal = new int[size, size];

      for (int row = 0; row < size; ++row)
      {
        for (int column = 0; column < size; ++column)
        {
          diagonal[row, column] = (row == column) ? matrix.MatrixElements[row, column] : 0;
        }
      }

      return new SquareMatrix(diagonal);
    };
  }
}