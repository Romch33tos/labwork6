using System;

namespace Matrix
{
  public static class MatrixExtensions
  {
    public static SquareMatrix Transpose(this SquareMatrix matrix)
    {
      int size = matrix.MatrixSize;
      int[,] transposed = new int[size, size];

      for (int row = 0; row < size; row++)
      {
        for (int col = 0; col < size; col++)
        {
          transposed[col, row] = matrix.MatrixElements[row, col];
        }
      }

      return new SquareMatrix(transposed);
    }

    public static int Trace(this SquareMatrix matrix)
    {
      int trace = 0;
      for (int i = 0; i < matrix.MatrixSize; i++)
      {
        trace += matrix.MatrixElements[i, i];
      }
      return trace;
    }

    public delegate SquareMatrix MatrixTransformDelegate(SquareMatrix matrix);

    public static MatrixTransformDelegate Diagonalize = delegate(SquareMatrix matrix)
    {
      int size = matrix.MatrixSize;
      int[,] diagonal = new int[size, size];

      for (int row = 0; row < size; row++)
      {
        for (int col = 0; col < size; col++)
        {
          diagonal[row, col] = (row == col) ? matrix.MatrixElements[row, col] : 0;
        }
      }

      return new SquareMatrix(diagonal);
    };
  }
}