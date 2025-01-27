namespace Methods;

class Program : Python
{
    private static bool _check = true;
    
    private static int[]? _array, _array2;
    
    private static int[,]? _matrix;

    private static int _n, _j, _i, _m;
    
    public static void Main(string[] args)
    {
        print("Классы, методы");
        
        //Random rand = new Random();

        while (_check)
        {
            int task = int.Parse(input("Введите задание: "));

            switch (task)
            {
                case 1:
                    _n = int.Parse(input("Введите кол-во чисел в массиве: "));

                    _array = GenerateArray(_n, 0, 51);
                    
                    PrintArr("Полученный массив", _array);

                    int znach = int.Parse(input("Значение которое не будет в новом массиве: "));
                    
                    _array = FilterExcludedValues(_array, znach);
                    
                    PrintArr("Отфильтрованный массив", _array);
                    
                    break;
                case 2:
                    _n = int.Parse(input("Введите кол-во чисел в массиве: "));
                    _array = GenerateArray(_n, 0, 51);
                    
                    PrintArr("Полученный массив", _array);

                    int index = int.Parse(input("Индекс элемента, который нужно убрать: "));
                    
                    PrintArr("Полученный массив", _array = FilterExcludedIndexes(_array, index));
                    
                    break;
                case 3:
                    _i = int.Parse(input("Введите кол-во строк матрицы: "));
                    _j = int.Parse(input("Введите кол-во столбцов матрицы: "));
                    
                    _matrix = GenerateMatrix(_i, _j, 0, 41);
                    
                    PrintMatrix(_matrix);

                    znach = int.Parse(input("Введите значение, которое нужно оставить: "));
                    int znach1 = int.Parse(input("Введите значение, на которое нужно заменить оставшиеся элементы: "));
                    
                    _matrix = ChangeElements(_matrix, znach, znach1);
                    
                    PrintMatrix(_matrix);
                    
                    break;
                case 4:
                    _n = int.Parse(input("Введите кол-во элементов 1-ого массива: "));
                    _m = int.Parse(input("Введите кол-во элементов 2-ого массива: "));
                    
                    _array = GenerateArray(_n, 0, 51);
                    _array2 = GenerateArray(_m, 0, 51);
                    
                    PrintArr("1-ый массив", _array);
                    PrintArr("2-ой массив", _array2);

                    var productA = CalculateProduct(_array);
                    var productB = CalculateProduct(_array2);
                    
                    CompareProducts(productA, productB);
                    
                    break;
                case 5:
                    _n = int.Parse(input("Введите n: "));
                    _m = int.Parse(input("Введите m: "));
                    
                    try
                    {
                        print($"\nСочетание этих чисел: {NumberOfCombinations(_n, _m)}");
                    }
                    catch (Exception e)
                    {
                        print(e.Message);
                    }

                    break;
                case 6:
                    _matrix = GenerateMatrix(5, 5, 0, 41);

                    PrintMatrix(_matrix);
                    
                    print($"\nМаксимальный элемент матрицы: {MaxElementInMatrix(_matrix)}");
                    print($"Кол-во вхождений максимального элемента в матрице: {CountOfMaxElement(_matrix, MaxElementInMatrix(_matrix))}");
                    
                    break;
                case 0:
                    _check = false;
                    break;
                default:
                    print("ошибка");
                    break;
            }
        }
    }

    /// <summary>
    /// Находит кол-во введенных элементов в матрице.
    /// </summary>
    /// <param name="matrix">Матрица, в которой производится подсчет.</param>
    /// <param name="maxElement">Элемент для поиска.</param>
    /// <returns>Число вхождений элемента.</returns>
    private static int CountOfMaxElement(int[,] matrix, int maxElement)
    {
        var count = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == maxElement)
                    count++;
            }
        }
        
        return count;
    }
    
    /// <summary>
    /// Находит максимальный элемент в матрице.
    /// </summary>
    /// <param name="matrix">Матрица, в которой производится поиск.</param>
    /// <returns>Максимальный элемент матрицы.</returns>
    private static int MaxElementInMatrix(int[,] matrix)
    {
        var max = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i,j] > max)
                    max = matrix[i,j];
            }
        }
        
        return max;
    }
    
    /// <summary>
    /// Находит сочетание n по m.
    /// </summary>
    /// <param name="n">Рот шатал я этого теория вероятности, тут короче n.</param>
    /// <param name="m">Кол-во элементов, взятых из множества.</param>
    /// <returns>Сочетание n элементов по m.</returns>
    private static long NumberOfCombinations(int n, int m)
    {
        if (m > n)
            throw new ArgumentException("\nЧисло m не может быть больше, чем n");
        
        return Factorial(n) / (Factorial(m) * Factorial(n - m));
    }

    /// <summary>
    /// Находит факториал заданного числа.
    /// </summary>
    /// <param name="n">Число для вычисления.</param>
    /// <returns>Факториал числа.</returns>
    private static long Factorial(int n) // это короче рекурсия, он там туда-сюда ходит метод этот
    {
        if (n <= 1)
            return 1;
        
        return n * Factorial(n - 1);
    }
    
    /// <summary>
    /// Считает произведение всех элементов массива.
    /// </summary>
    /// <param name="array">Массив чисел.</param>
    /// <returns>Одномерный массив.</returns>
    private static long CalculateProduct(int[] array)
    {
        long product = 1;
        foreach (var num in array)
        {
            product *= num;
        }
        
        return product;
    }
    
    /// <summary>
    /// Сравнивает произведения двух массивов и выводит результат.
    /// </summary>
    /// <param name="productA">Произведение 1-ого массива.</param>
    /// <param name="productB">Произведение 2-ого массива.</param>
    private static void CompareProducts(long productA, long productB)
    {
        if (productA > productB)
            print("Произведение элементов 1-ого массива, больше чем 2-ого");
        else if (productA < productB)
            print("Произведение элементов 2-ого массива, больше чем 1-ого");
        else
            print("Произведение элементов массивов одинаково");
    }
    
    /// <summary>
    /// Заменяет все элементы в матрице, оставляя только нужные.
    /// </summary>
    /// <param name="matrix">Матрица, в которой нужно произвести замену.</param>
    /// <param name="znach">Значение, которое нужно оставить.</param>
    /// <param name="znach1">Значение, на которое нужно заменить оставшиеся элементы.</param>
    /// <returns>Двумерный массив.</returns>
    private static int[,] ChangeElements(int[,] matrix, int znach, int znach1)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == znach)
                    continue;
                
                matrix[i, j] = znach1;
            }
        }
        
        return matrix;
    }
    
    /// <summary>
    /// Убирает из массива элемент по введенному индексу.
    /// </summary>
    /// <param name="array">Массив из которого нужно убрать значение.</param>
    /// <param name="index">Индекс по которому уберется значение.</param>
    /// <returns>Одномерный массив.</returns>
    private static int[] FilterExcludedIndexes(int[] array, int index)
    {
        return array.Where((value, i) => i != index).ToArray();
    }
    
    /// <summary>
    /// Убирает из массива введенное значение.
    /// </summary>
    /// <param name="array">Массив из которого нужно убрать значение.</param>
    /// <param name="znach">Значение которое нужно убрать.</param>
    /// <returns>Одномерный массив.</returns>
    private static int[] FilterExcludedValues(int[] array, int znach)
    {
        return array.Where(x => x != znach).ToArray();
    }
    
    /// <summary>
    /// Возвращает массив случайных чисел, по-заданному кол-ву чисел и в заданном диапазоне.
    /// </summary>
    /// <param name="numberOfValues">Кол-во чисел.</param>
    /// <param name="minValue">Минимальное значение.</param>
    /// <param name="maxValue">Максимальное значение.</param>
    /// <returns>Одномерный массив.</returns>
    private static int[] GenerateArray(int numberOfValues, int minValue, int maxValue)
    {
        Random rand = new Random();
        int[] array = new int[numberOfValues];
        
        for (int i = 0; i < numberOfValues; i++)
        {
            array[i] = rand.Next(minValue, maxValue);
        }
        
        return array;
    }

    /// <summary>
    /// Создает матрицу, заполненную случайными числами.
    /// </summary>
    /// <param name="rows">Количество строк.</param>
    /// <param name="columns">Количество столбцов.</param>
    /// <param name="minValue">Минимальное значение элементов.</param>
    /// <param name="maxValue">Максимальное значение элементов.</param>
    /// <returns>Двумерный массив.</returns>
    private static int[,] GenerateMatrix(int rows, int columns, int minValue, int maxValue)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue);
            }
        }
        
        return matrix;
    }
}