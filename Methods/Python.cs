namespace Methods;

public class Python
{
    protected static void print()
    {
        Console.WriteLine();
    }

    protected static void print<T>(T s)
    {
        Console.WriteLine(s);
    }

    protected static string input()
    {
        return Console.ReadLine() ?? string.Empty;
    }

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
}
