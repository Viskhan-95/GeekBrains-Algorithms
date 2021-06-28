using System;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            //В задании п.3 говорится проверку сделать в main
            while (true)
            {
                Console.Write("Введите число: ");
                string str = Console.ReadLine();

                int number = ConvertToInt(str);
                
                if (number > 0)
                {
                    CheckPrimeNumber(number);
                    break;
                }
                else
                    Console.WriteLine("Число должно быть больше нуля, попробуйте еще раз");
            }
        }


        //Метод проверяет является ли введенное число простым или составным
        static void CheckPrimeNumber(int n)
        {
            int d = 0;
            int i = 2;

            while(i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                    i++;
            }
            if(d == 0)
                Console.WriteLine($"{n} - простое число");
            else
                Console.WriteLine($"{n} - не простое (составное) число");
        }


        //Метод конвертирует введенную строку в число
        static int ConvertToInt(string str)
        {
            while (true)
            {
                if (int.TryParse(str, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число, попробуй  те еще раз");
                    str = Console.ReadLine();
                }
            }
        }
    }
}
