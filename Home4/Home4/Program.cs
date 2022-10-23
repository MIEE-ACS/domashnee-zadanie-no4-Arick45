using System;
using System.Collections.Generic;
namespace HomeTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Заполняем массив
            Console.WriteLine("Укажите длинну массива");
            Random rand = new Random();
            int len;
            int[] array;
            try
            {
                len = int.Parse(Console.ReadLine());
                array = new int[len];
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Не положительная длинна");
                return;
            }

            for (int i = 0; i < len; i++)
            {
                array[i] = rand.Next(-1000, 1000) % 10;
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("-----------Масссив до изменения----------------");
            foreach (var item in array)//распечатываем
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------");
            // часть 1
            int count = 0, zeroLastElIn = -1, countone = 0, sum = 0;
            for (int i = 0; i < len; i++)//определение последнего нуля и сумма положительных элементов
            {
                if (array[i] > 0)
                {
                    count++;
                }
                if (array[i] == 0)
                {
                    zeroLastElIn = i;
                }
            }
            if (zeroLastElIn == -1)
            {
                Console.WriteLine("Нету чисел равных нулю");
            }
            else
            {
                for (int i = zeroLastElIn + 1; i < len; i++)//сумма элементов после последнего нуля
                {
                    sum += array[i];
                }
                Console.WriteLine($"Последний нулевой элемент на позиции: {zeroLastElIn + 1}");
                Console.WriteLine($"Cумма элементов массива, расположенных после последнего элемента,равного нулю: {sum}");
            }
            for (int i = 0; i < len; i++)//изменяем массив
            {
                if (array[i] <= 1)
                {
                    int temp = array[countone];
                    array[countone] = array[i];
                    array[i] = temp;
                    countone++;
                }
            }
            Console.WriteLine("----------------------------------------------");
            // часть 2
            Console.WriteLine($"Количество положительных чисел в массиве: {count}");
            Console.WriteLine("-----------Масссив после изменения----------------");
            foreach (var item in array)//распечатываем
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}