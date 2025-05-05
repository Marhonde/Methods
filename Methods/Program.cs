namespace Methods;

internal abstract class Program : Python
{
    private static bool _check = true;
    private static int[]? _array, _array2;
    private static double[]? _doubleArray, _doubleArray1, _doubleArray2;
    private static int[,]? _matrix;
    private static int _n, _j, _i, _m;
    
    public static void Main()
    {
        print("Классы, методы");

        while (_check)
        {
            var task = int.Parse(input("Введите задание: "));

            switch (task)
            {
                case 1:
                    _n = int.Parse(input("Введите кол-во чисел в массиве: "));
                    _array = GenerateArray(_n, 0, 51);
                    
                    PrintArr("Полученный массив", _array);

                    var value = int.Parse(input("Значение которое не будет в новом массиве: "));
                    _array = FilterExcludedValues(_array, value);
                    
                    PrintArr("Отфильтрованный массив", _array);
                    
                    break;
                case 2:
                    _n = int.Parse(input("Введите кол-во чисел в массиве: "));
                    _array = GenerateArray(_n, 0, 51);
                    
                    PrintArr("Полученный массив", _array);

                    var index = int.Parse(input("Индекс элемента, который нужно убрать: "));
                    
                    PrintArr("Полученный массив", _array = FilterExcludedIndexes(_array, index));
                    
                    break;
                case 3:
                    _i = int.Parse(input("Введите кол-во строк матрицы: "));
                    _j = int.Parse(input("Введите кол-во столбцов матрицы: "));
                    
                    _matrix = GenerateMatrix(_i, _j, 0, 41);
                    
                    PrintMatrix(_matrix);

                    value = int.Parse(input("Введите значение, которое нужно оставить: "));
                    var value1 = int.Parse(input("Введите значение, на которое нужно заменить оставшиеся элементы: "));
                    
                    _matrix = ChangeElements(_matrix, value, value1);
                    
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
                    _matrix = PrintGenerateMatrix(5, 5, 0, 41);
                    
                    print($"\nМаксимальный элемент матрицы: {MaxElementInMatrix(_matrix)}");
                    print($"Кол-во вхождений максимального элемента в матрице: {CountOfMaxElement(_matrix, MaxElementInMatrix(_matrix))}");
                    
                    break;
                case 7:
                    _n = int.Parse(input("Введите кол-во элементов в массивах: "));
                    
                    _doubleArray = GenerateDoubleArray(_n, 0, 51);
                    _doubleArray1 = GenerateDoubleArray(_n, 0, 51);
                    _doubleArray2 = GenerateDoubleArray(_n, 0, 51);
                    
                    PrintArr("1-ый массив", _doubleArray);
                    PrintArr("2-ой массив", _doubleArray1);
                    PrintArr("3-ий массив", _doubleArray2);

                    try
                    {
                        SolvingGroupQuadEquations(_doubleArray, _doubleArray1, _doubleArray2);
                    }
                    catch (Exception e)
                    {
                        print(e.Message);
                    }
                    
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
    /// Решает группу квадратных уравнений по элементам каждого массива.
    /// </summary>
    /// <param name="array">Массив для значений p.</param>
    /// <param name="array1">Массив для значений q.</param>
    /// <param name="array2">Массив для значений r.</param>
    /// <exception cref="ArgumentException">
    /// Значение p не должно равняться 0.
    /// </exception>
    private static void SolvingGroupQuadEquations(double[] array, double[] array1, double[] array2)
    {
        if (array.Length != array1.Length && array1.Length != array2.Length && array.Length != array1.Length)
            throw new ArgumentException("Кол-во элементов в массивах должно быть одинаково");
        
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                var d = Math.Pow(array1[i], 2) - 4 * array[i] * array2[i];

                switch (d)
                {
                    case > 0:
                    {
                        var result = (-array1[i] + Math.Sqrt(d)) / (2 * array[i]);
                        var result1 = (-array1[i] - Math.Sqrt(d)) / (2 * array[i]);
                    
                        print($"Ответ {i + 1}-ых элементов = {result:F} и {result1:F}");
                        break;
                    }
                    case 0:
                    {
                        var result = -array1[i] / (2 * array[i]);
                    
                        print($"Ответ {i + 1} элементов = {result:F}");
                        break;
                    }
                    default:
                        print("Корней нет");
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Значение p не должно равняться 0");
            }
        }
    }

    /// <summary>
    /// Создает матрицу, заполненную случайными числами и выводит ее
    /// </summary>
    /// <param name="rows">Кол-во строк матрицы.</param>
    /// <param name="columns">Кол-во столбцов матрицы.</param>
    /// <param name="minValue">Минимальное значение.</param>
    /// <param name="maxValue">Максимальное значение</param>
    /// <returns>Двумерный массив.</returns>
    private static int[,] PrintGenerateMatrix(int rows, int columns, int minValue, int maxValue)
    {
        var rand = new Random();
        var matrix = new int[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue);
            }
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            print();
        }
        
        return matrix;
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

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
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

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
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
        return array.Aggregate<int, long>
            (1, (current, num) => current * num);
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
    /// <param name="value">Значение, которое нужно оставить.</param>
    /// <param name="value1">Значение, на которое нужно заменить оставшиеся элементы.</param>
    /// <returns>Двумерный массив.</returns>
    private static int[,] ChangeElements(int[,] matrix, int value, int value1)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == value)
                    continue;
                
                matrix[i, j] = value1;
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
        return array.Where((_, i) => i != index).ToArray();
    }
    
    /// <summary>
    /// Убирает из массива введенное значение.
    /// </summary>
    /// <param name="array">Массив из которого нужно убрать значение.</param>
    /// <param name="value">Значение которое нужно убрать.</param>
    /// <returns>Одномерный массив.</returns>
    private static int[] FilterExcludedValues(int[] array, int value)
    {
        return array.Where(x => x != value).ToArray();
    }
    
    /// <summary>
    /// Возвращает массив случайных целых чисел, по-заданному кол-ву чисел и в заданном диапазоне.
    /// </summary>
    /// <param name="numberOfValues">Кол-во чисел.</param>
    /// <param name="minValue">Минимальное значение.</param>
    /// <param name="maxValue">Максимальное значение.</param>
    /// <returns>Одномерный массив.</returns>
    private static int[] GenerateArray(int numberOfValues, int minValue, int maxValue)
    {
        var rand = new Random();
        var array = new int[numberOfValues];
        
        for (var i = 0; i < numberOfValues; i++)
        {
            array[i] = rand.Next(minValue, maxValue);
        }
        
        return array;
    }

    /// <summary>
    /// Возвращает массив случайных чисел с плавающей точкой, по-заданному кол-ву чисел и в заданном диапазоне.
    /// </summary>
    /// <param name="numberOfValues">Кол-во элементов массива.</param>
    /// <param name="minValue">Минимальное значение.</param>
    /// <param name="maxValue">Максимальное значение.</param>
    /// <returns>Одномерный массив.</returns>
    private static double[] GenerateDoubleArray(int numberOfValues, int minValue, int maxValue)
    {
        var array = new double[numberOfValues];

        for (var i = 0; i < numberOfValues; i++)
        {
            array[i] = Math.Round(RandomDouble(minValue, maxValue), 3);
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
        var rand = new Random();
        var matrix = new int[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue);
            }
        }
        
        return matrix;
    }
}