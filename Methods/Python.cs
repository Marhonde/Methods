namespace Methods;

public class Python
{
    public static void print()
    {
        Console.WriteLine();
    }

    public static void print(string s)
    {
        Console.WriteLine(s);
    }

    public static void print(int s)
    {
        Console.WriteLine(s);
    }

    public static void print(double s)
    {
        Console.WriteLine(s);
    }

    public static string input()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public static string input(string s)
    {
        Console.Write(s);
        return Console.ReadLine() ?? string.Empty;
    }
    
    /// <summary>
    /// Выводит одномерный массив в виде: [0, 1, 2]
    /// </summary>
    /// <param name="array">Массив который нужно вывести</param>
    /// <param name="s">Строка подсказка</param>
    public static void PrintArr(string s, int[] array)
    {
        print($"{s}: [{string.Join(", ", array)}]");
    }
}
