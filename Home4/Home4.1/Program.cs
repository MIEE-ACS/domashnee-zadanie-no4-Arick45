using System;
class Program
{
    static void Main(string[] args)
    {
        int len = 0, choose;
        double[,] array;
        Console.WriteLine("Ввидите кол-во столбцов квадратной матрицы");
        try
        {
            len = int.Parse(Console.ReadLine());
            array = new double[len, len];
        }
        catch (FormatException)//проверка на число
        {
            Console.WriteLine("Некорректный ввод(возможно вы ввели не целое положительное число)");
            return;

        }
        catch (OverflowException)//проверка на положительность
        {
            Console.WriteLine("Не положительная длинна");
            return;
        }
        Console.WriteLine("Массив :");
        Console.WriteLine("Хотите сами заполнить,да=1,нет любое другое число");
        try
        {
            choose = int.Parse(Console.ReadLine());
        }
        catch (FormatException)//проверка на число
        {
            Console.WriteLine("вы ввели не целое число");
            return;
        }
        if (choose == 1)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine("Ввидите элемент {0}строки и {1} столбца", i, j);
                    try
                    {
                        array[i, j] = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Некорректный ввод, ввидите число");
                        return;
                    }
                }
            };
        }
        else
        {
            MArray(array);//заполнение автоматическое
        }
        PrintArray(array);
        Console.WriteLine("\n");
        Found(array);
        array = Replace(array);
        Console.WriteLine("После перестановки :\n");
        PrintArray(array);
        Console.ReadKey();

        static double[,] Replace(double[,] array)//функция перестановки
        {
            for (int n = 0; n < array.GetLength(0); n++)
            {
                int row = 0, col = 0;
                double max = double.MinValue;

                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (i != j || i > n)
                            if (array[i, j] > max)
                            {
                                max = array[i, j];
                                row = i; col = j;
                            }
                    }
                double temp = array[n, n];
                array[n, n] = array[row, col];
                array[row, col] = temp;
            }
            return array;
        }
        static void PrintArray(Array a)//функция вывода
        {
            Action<object> print = o => Console.Write("{0}\t", o);

            for (int i = 0; i < a.GetLength(0); i++)

            {
                for (int j = 0; j < a.GetLength(1); j++)
                    print(a.GetValue(i, j));
                Console.WriteLine();
            }
        }
        static void MArray(double[,] array)//функция заполнения
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Math.Round((double)rand.NextDouble() * 10.0 - 1.0, 2);

                }
                Console.WriteLine();
            }
        }
        static void Found(double[,] array)// ищем строку по заданию
        {
            bool isFound = true;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    isFound = true;
                    if (array[i, j] > 0)
                    {
                        isFound = false;
                        break;
                    }
                }
                if (isFound) { Console.WriteLine("Строка {0},", i); break; }
            }
            if (!isFound) Console.WriteLine("нету такой строки");
        }
    }
}
