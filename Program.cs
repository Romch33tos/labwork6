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

      additionHandler.SetNext(subtractionHandler);
      subtractionHandler.SetNext(multiplicationHandler);
      multiplicationHandler.SetNext(determinantHandler);
      determinantHandler.SetNext(inverseHandler);
      inverseHandler.SetNext(transposeHandler);
      transposeHandler.SetNext(traceHandler);
      traceHandler.SetNext(diagonalizeHandler);

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
        Console.WriteLine("1. Сложение матриц");
        Console.WriteLine("2. Вычитание матриц");
        Console.WriteLine("3. Умножение матриц");
        Console.WriteLine("4. Вычислить детерминант");
        Console.WriteLine("5. Найти обратную матрицу");
        Console.WriteLine("6. Транспонировать матрицу");
        Console.WriteLine("7. Найти след матрицы");
        Console.WriteLine("8. Привести к диагональному виду");
        Console.WriteLine("0. Выход");

        Console.Write("Ваш выбор: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 8)
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
        throw new ArgumentException("Некорректный выбор способа создания матрицы");
      }

      Console.Write("Введите размер матрицы (1-3): ");
      if (!int.TryParse(Console.ReadLine(), out int size) || size < 1 || size > 3)
      {
        throw new ArgumentException("Некорректный размер матрицы");
      }

      if (choice == 1)
      {
        Console.WriteLine($"Введите {size * size} элементов матрицы через пробел:");
        string[] elements = Console.ReadLine().Split(' ');
        if (elements.Length != size * size)
        {
          throw new ArgumentException($"Ожидается {size * size} элементов");
        }

        int[] intElements = new int[size * size];
        for (int i = 0; i < elements.Length; i++)
        {
          if (!int.TryParse(elements[i], out intElements[i]))
          {
            throw new ArgumentException($"Некорректный элемент: {elements[i]}");
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