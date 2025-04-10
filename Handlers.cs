using System;

namespace Matrix
{
  public abstract class MatrixHandler
  {
    protected MatrixHandler nextHandler;

    public void SetNext(MatrixHandler handler)
    {
      nextHandler = handler;
    }

    public abstract void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice);
  }

  public class AdditionHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 1)
      {
        Console.WriteLine("Результат сложения:");
        Console.WriteLine(matrix1 + matrix2);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class SubtractionHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 2)
      {
        Console.WriteLine("Результат вычитания:");
        Console.WriteLine(matrix1 - matrix2);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class MultiplicationHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 3)
      {
        Console.WriteLine("Результат умножения:");
        Console.WriteLine(matrix1 * matrix2);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class DeterminantHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 4)
      {
        Console.WriteLine("Детерминант первой матрицы: " + matrix1.CalculateDeterminant());
        Console.WriteLine("Детерминант второй матрицы: " + matrix2.CalculateDeterminant());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class InverseHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 5)
      {
        Console.WriteLine("Обратная матрица для первой матрицы:");
        Console.WriteLine(matrix1.InverseMatrix());
        Console.WriteLine("Обратная матрица для второй матрицы:");
        Console.WriteLine(matrix2.InverseMatrix());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class TransposeHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 6)
      {
        Console.WriteLine("Транспонированная первая матрица:");
        Console.WriteLine(matrix1.Transpose());
        Console.WriteLine("Транспонированная вторая матрица:");
        Console.WriteLine(matrix2.Transpose());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class TraceHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 7)
      {
        Console.WriteLine("След первой матрицы: " + matrix1.Trace());
        Console.WriteLine("След второй матрицы: " + matrix2.Trace());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }

  public class DiagonalizeHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix matrix1, SquareMatrix matrix2, int choice)
    {
      if (choice == 8)
      {
        Console.WriteLine("Диагональный вид первой матрицы:");
        Console.WriteLine(MatrixExtensions.Diagonalize(matrix1));
        Console.WriteLine("Диагональный вид второй матрицы:");
        Console.WriteLine(MatrixExtensions.Diagonalize(matrix2));
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(matrix1, matrix2, choice);
      }
    }
  }
}