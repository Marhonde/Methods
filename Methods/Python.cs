namespace Methods;

public class Python
{
    /// <summary>
    /// Ренейм Console.WriteLine().
    /// </summary>
    protected static void print()
    {
        Console.WriteLine();
    }

    /// <summary>
    /// Ренейм Console.WriteLine().
    /// </summary>
    /// <param name="s">Строка, которую нужно вывести</param>
    /// <typeparam name="T">Тип элементов источника.</typeparam>
    protected static void print<T>(T s)
    {
        Console.WriteLine(s);
    }

    /// <summary>
    /// Ренейм Console.ReadLine().
    /// </summary>
    /// <returns>Следующая строка символов из входного потока или null, если больше нет доступных строк.</returns>
    protected static string input()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    /// <summary>
    /// Ренейм Console.ReadLine().
    /// </summary>
    /// <param name="s">Строка подсказка</param>
    /// <returns>Следующая строка символов из входного потока или null, если больше нет доступных строк.</returns>
    protected static string input(string s)
    {
        Console.Write(s);
        return Console.ReadLine() ?? string.Empty;
    }

    /// <summary>
    /// Выводит одномерный массив в виде: [0, 1, 2].
    /// </summary>
    /// <param name="array">Массив который нужно вывести.</param>
    /// <param name="s">Строка подсказка.</param>
    protected static void PrintArr<T>(string s, IEnumerable<T> array)
    {
        print($"{s}: [{string.Join(", ", array)}]");
    }

    /// <summary>
    /// Выводит матрицу.
    /// </summary>
    /// <param name="matrix">Массив который нужно вывести.</param>
    /// <typeparam name="T">Тип элементов источника.</typeparam>
    protected static void PrintMatrix<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            print();
        }
    }

    /// <summary>
    /// Создает случайное число, с плавающей точкой в заданном диапазоне.
    /// </summary>
    /// <param name="minValue">Минимальное значение.</param>
    /// <param name="maxValue">Максимальное значение.</param>
    /// <returns>Число с плавающей точкой.</returns>
    protected static double RandomDouble(double minValue, double maxValue)
    {
        var random = new Random();
        var range = maxValue - minValue;
        var sample = random.NextDouble();
        return (sample * range) + minValue;
    }
}
