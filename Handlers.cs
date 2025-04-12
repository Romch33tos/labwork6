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

    public abstract void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice);
  }

  public class AdditionHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 1)
      {
        Console.WriteLine("Результат сложения:");
        Console.WriteLine(firstMatrix + secondMatrix);
      } 
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class SubtractionHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 2)
      {
        Console.WriteLine("Результат вычитания:");
        Console.WriteLine(firstMatrix - secondMatrix);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class MultiplicationHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 3)
      {
        Console.WriteLine("Результат умножения:");
        Console.WriteLine(firstMatrix * secondMatrix);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class DeterminantHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 4)
      {
        Console.WriteLine("Детерминант первой матрицы: " + firstMatrix.CalculateDeterminant());
        Console.WriteLine("Детерминант второй матрицы: " + secondMatrix.CalculateDeterminant());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class InverseHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 5)
      {
        Console.WriteLine("Обратная матрица для первой матрицы:");
        Console.WriteLine(firstMatrix.InverseMatrix());
        Console.WriteLine("Обратная матрица для второй матрицы:");
        Console.WriteLine(secondMatrix.InverseMatrix());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class TransposeHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 6)
      {
        Console.WriteLine("Транспонированная первая матрица:");
        Console.WriteLine(firstMatrix.Transpose());
        Console.WriteLine("Транспонированная вторая матрица:");
        Console.WriteLine(secondMatrix.Transpose());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class TraceHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 7)
      {
        Console.WriteLine("След первой матрицы: " + firstMatrix.Trace());
        Console.WriteLine("След второй матрицы: " + secondMatrix.Trace());
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class DiagonalizeHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 8)
      {
        Console.WriteLine("Диагональный вид первой матрицы:");
        Console.WriteLine(MatrixExtensions.Diagonalize(firstMatrix));
        Console.WriteLine("Диагональный вид второй матрицы:");
        Console.WriteLine(MatrixExtensions.Diagonalize(secondMatrix));
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class MatrixComparisonHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 9)
      {
        Console.WriteLine("Сравнение матриц:");
        Console.WriteLine($"Матрица 1 > Матрица 2: {firstMatrix > secondMatrix}");
        Console.WriteLine($"Матрица 1 < Матрица 2: {firstMatrix < secondMatrix}");
        Console.WriteLine($"Матрица 1 >= Матрица 2: {firstMatrix >= secondMatrix}");
        Console.WriteLine($"Матрица 1 <= Матрица 2: {firstMatrix <= secondMatrix}");
        Console.WriteLine($"Матрица 1 == Матрица 2: {firstMatrix == secondMatrix}");
        Console.WriteLine($"Матрица 1 != Матрица 2: {firstMatrix != secondMatrix}");
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }

  public class TypeConversionDemoHandler : MatrixHandler
  {
    public override void HandleRequest(SquareMatrix firstMatrix, SquareMatrix secondMatrix, int operationChoice)
    {
      if (operationChoice == 10)
      {
        Console.WriteLine("Демонстрация приведения типов:");
        string matrixString = (string)firstMatrix;
        
        Console.WriteLine("Явное приведение к string:");
        Console.WriteLine(matrixString);

        int[,] matrixArray = (int[,])firstMatrix;
        Console.WriteLine("Явное приведение к int[,]:");

        for (int rowIndex = 0; rowIndex < firstMatrix.MatrixSize; ++rowIndex)
        {
          for (int columnIndex = 0; columnIndex < firstMatrix.MatrixSize; ++columnIndex)
          {
            Console.Write($"{matrixArray[rowIndex, columnIndex]} ");
          }
          Console.WriteLine();
        }

        int[] elements = { 1, 2, 3, 4 };
        SquareMatrix implicitMatrix = elements;
        Console.WriteLine("Неявное приведение из int[]:");
        Console.WriteLine(implicitMatrix);
      }
      else if (nextHandler != null)
      {
        nextHandler.HandleRequest(firstMatrix, secondMatrix, operationChoice);
      }
    }
  }
}