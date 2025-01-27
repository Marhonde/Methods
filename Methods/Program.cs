namespace Methods;

class Program : Python
{
    public static void Main(string[] args)
    {
        print("Классы, методы");
        
        //Random rand = new Random();
        
        bool check = true;

        while (check)
        {
            int task = int.Parse(input("Введите задание: "));

            switch (task)
            {
                case 1:
                    int n = int.Parse(input("Введите кол-во чисел в массиве: "));
                    
                    int[] a = new int[n];

                    a = GenerateArray(n, 0, 51);
                    
                    PrintArr("Полученный массив", a);
                    
                    break;
                case 0:
                    check = false;
                    break;
                default:
                    print("ошибка");
                    break;
            }
        }
    }
    
    /// <summary>
    /// Возвращает массив случайных чисел по заданому кол-ву чисел и в заданном диапазоне
    /// </summary>
    /// <param name="numberOfValues">Кол-во чисел</param>
    /// <param name="minValue">Минимальное значение</param>
    /// <param name="maxValue">Максимальное значение</param>
    /// <returns>Одномерный массив</returns>
    static int[] GenerateArray(int numberOfValues, int minValue, int maxValue)
    {
        Random rand = new Random();
        int[] array = new int[numberOfValues];
        
        for (int i = 0; i < numberOfValues; i++)
        {
            array[i] = rand.Next(minValue, maxValue);
        }
        
        return array;
    }
}