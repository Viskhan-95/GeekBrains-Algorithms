using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DZ4
{
    class Program
    {
        static class TestMethods
        {
            public static double GetTime(Action act)
            {
                /*
                 * Сначала решил рассчитать среднеарефметическую из 10 запросов на поиск, как в задании к прошлому уроку
                 * но почему-то в таком случае время на поиск в массиве тратится меньше, чем в hashset
                 * а если сделать однократный поиск, то hash намного быстрее делает поиск
                 */
                Stopwatch sw;
                sw = new Stopwatch();
                sw.Start();
                act();
                sw.Stop();
                return sw.ElapsedTicks;
            }
        }


        static string[] FillingArray(string[] array)
        {
            var arrayRandomString = new string[20_000];

            for (int i = 0; i < array.Length; i++)  arrayRandomString[i] = array[i];
            return arrayRandomString;
        }


        static HashSet<string> FillingНashSet(string[] array)
        {
            var hash = new HashSet<string>();

            for (int i = 0; i < array.Length; i++)  hash.Add(array[i]);
            return hash;
        }


        static string SearchStringInArray(string[] arrayString, string find)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            foreach (var s in arrayString)
            {
                if (s == find)
                {//Можно было создать метод, чтоб не дублировать выводимую на консоль инфо
                    sw.Stop();
                    Console.WriteLine($"       Method (поиск)        | Time");
                    Console.WriteLine($"-----------------------------|-----");
                    Console.WriteLine($"SearchStringInArray          | {sw.ElapsedTicks}");
                    
                    return s;
                }
            }
            sw.Stop();
            Console.WriteLine($"       Method (поиск)        | Time");
            Console.WriteLine($"-----------------------------|-----");
            Console.WriteLine($"SearchStringInArray          | {sw.ElapsedTicks}");
            
            return $"{find} нет в массиве";
        }


        static string SearchStringInHashSet(HashSet<string> hash, string find)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (hash.Contains(find))
            {
                sw.Stop();
                Console.WriteLine($"SearchStringInHashSet        | {sw.ElapsedTicks}");
                return find;

            }     
            else
            {
                sw.Stop();
                Console.WriteLine($"SearchStringInHashSet        | {sw.ElapsedTicks}");
                return $"{find} нет в hash";
            }
        }


        static void Main(string[] args)
        {
            //Заполнил массив строк здесь, чтоб в SearchArray и SearchHashSet значения были одинаковыми
            Random rnd = new Random();
            var randomString = new string[20_000];

            for (int i = 1; i < randomString.Length; i++)
                randomString[i] = rnd.Next(1, 30_000).ToString();

            double timeArray = 0;
            double timeHash = 0;
            
            timeArray = TestMethods.GetTime(() => SearchStringInArray(FillingArray(randomString), "25890"));
            timeHash = TestMethods.GetTime(() => SearchStringInHashSet(FillingНashSet(randomString), "25890"));

            Console.WriteLine();

            Console.WriteLine($"Method (заполнение и поиск)  | Time");
            Console.WriteLine($"-----------------------------|-----");
            
            Console.WriteLine($"SearchStringInArray          | {timeArray}");
            Console.WriteLine($"SearchStringInHashSet        | {timeHash}");
        }
    }
}
