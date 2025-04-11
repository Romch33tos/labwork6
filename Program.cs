using System;

namespace Matrix
{
  class Program
  {
    static void Main(string[] args)
    {
      var additionHandler = new AdditionHandler();
      var subtractionHandler = new SubtractionHandler();
      var multiplicationHandler = new MultiplicationHandler();

      var determinantHandler = new DeterminantHandler();
      var inverseHandler = new InverseHandler();     
      var transposeHandler = new TransposeHandler();
      
      var traceHandler = new TraceHandler();
      var diagonalizeHandler = new DiagonalizeHandler();
      var comparisonHandler = new MatrixComparisonHandler();
      var typeConversionHandler = new TypeConversionDemoHandler();

      additionHandler.SetNext(subtractionHandler);
      subtractionHandler.SetNext(multiplicationHandler);
      multiplicationHandler.SetNext(determinantHandler);

      determinantHandler.SetNext(inverseHandler);
      inverseHandler.SetNext(transposeHandler);
      transposeHandler.SetNext(traceHandler);

      traceHandler.SetNext(diagonalizeHandler);
      diagonalizeHandler.SetNext(comparisonHandler);
      comparisonHandler.SetNext(typeConversionHandler);

      SquareMatrix matrix1 = null;
      SquareMatrix matrix2 = null;

      while (matrix1 == null)
      {
        try
        {
          Console.WriteLine("Создание первой матрицы:");
          matrix1 = CreateMatrix();
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова.");
        }
      }

      while (matrix2 == null)
      {
        try
        {
          Console.WriteLine("Создание второй матрицы:");
          matrix2 = CreateMatrix();
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова.");
        }
      }

      Console.WriteLine("\nПервая матрица:");
      Console.WriteLine(matrix1);
      Console.WriteLine("Вторая матрица:");
      Console.WriteLine(matrix2);

      while (true)
      {
        Console.WriteLine("\nВыберите операцию:");
        Console.WriteLine("1. Выполнить сложение матриц");
        Console.WriteLine("2. Выполнить вычитание матриц");
        Console.WriteLine("3. Выполнить умножение матриц");
        Console.WriteLine("4. Вычислить детерминант");
        Console.WriteLine("5. Найти обратную матрицу");
        Console.WriteLine("6. Транспонировать матрицу");
        Console.WriteLine("7. Вычислить след матрицы");
        Console.WriteLine("8. Привести к диагональному виду");
        Console.WriteLine("9. Сравнить матрицы");
        Console.WriteLine("10. Демонстрация приведения типов");
        Console.WriteLine("0. Выход");
        Console.Write("Ваш выбор: ");
        
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 10)
        {
          Console.WriteLine("Некорректный ввод. Попробуйте снова.");
        }

        if (choice == 0)
        {
          break;
        }
        
        try
        {
          additionHandler.HandleRequest(matrix1, matrix2, choice);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Ошибка при выполнении операции: {ex.Message}");
        }
      }
    }

    static SquareMatrix CreateMatrix()
    {
      Console.WriteLine("Выберите способ создания матрицы:");
      Console.WriteLine("1. Вручную");
      Console.WriteLine("2. Автозаполнение");
      Console.Write("Ваш выбор: ");
      
      if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
      {
        throw new ArgumentException("Некорректный выбор способа создания матрицы.");
      }

      Console.Write("Введите размер матрицы (1-3): ");
      
      if (!int.TryParse(Console.ReadLine(), out int size) || size < 1 || size > 3)
      {
        throw new ArgumentException("Некорректный размер матрицы.");
      }

      if (choice == 1)
      {
        Console.WriteLine("Введите элементы матрицы через пробел:");
        string[] elements = Console.ReadLine().Split(' ');
        
        if (elements.Length != size * size)
        {
          throw new ArgumentException("Ошибка при вводe.");
        }

        int[] intElements = new int[size * size];
        for (int elementIndex = 0; elementIndex < elements.Length; ++elementIndex)
        {
          if (!int.TryParse(elements[elementIndex], out intElements[elementIndex]))
          {
            throw new ArgumentException("Недопустимый ввод.");
          }
        }

        return new SquareMatrix(intElements);
      }

      else
      {
        var matrix = new SquareMatrix(new int[size, size]);
        matrix.AutoFill(size);
        return matrix;
      }
    }
  }
}
