using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = ReadLine();
            int numberFibo = FibonacciRecursion(number);

            Console.WriteLine(numberFibo);
        }


        //Метод поиска числа Фибоначчи с помощью рекурсии
        static int FibonacciRecursion(int number)
        {
            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                return FibonacciRecursion(number - 2) + FibonacciRecursion(number - 1);
            }
        }


        //Метод поиска числа Фибоначчи с помощью цикла
        static int FibonacciCycle(int number)
        {
            int fiboStart = 0;
            int fiboFinish = 1;
            int sum;

            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    sum = fiboStart + fiboFinish;
                    fiboStart = fiboFinish;
                    fiboFinish = sum;
                }
                return fiboFinish;
            }    

        }


        //Метод получения введенной пользователем строки
        static int ReadLine()
        {
            while(true)
            {
                Console.WriteLine("Введите число");
                int number = ConvertToInt(Console.ReadLine());

                if (number >= 0)
                    return number;
                else
                    Console.WriteLine("Число должно быть больше нуля");
            }
        }


        //Метод конвертация строки в число
        static int ConvertToInt(string str)
        {
            while (true)
            {
                if (int.TryParse(str, out int result))
                    return result;
                else
                {
                    Console.WriteLine("Вы ввели не число, введите еще раз");
                    str = Console.ReadLine();
                }
            }
        }
    }
}
