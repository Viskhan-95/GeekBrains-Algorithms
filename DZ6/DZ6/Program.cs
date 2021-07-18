using System;

namespace DZ6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Для наглядности решил вручную заполнит граф
            int[,] graph =  {
                         { 0, 9, 0, 0, 0, 0, 0, 12, 0 },
                         { 9, 0, 12, 0, 0, 0, 0, 14, 0 },
                         { 0, 12, 0, 8, 0, 9, 0, 0, 5 },
                         { 0, 0, 8, 0, 12, 19, 0, 0, 0 },
                         { 0, 0, 0, 12, 0, 13, 0, 0, 0 },
                         { 0, 0, 9, 0, 13, 0, 5, 0, 0 },
                         { 0, 0, 0, 19, 0, 5, 0, 4, 9 },
                         { 12, 14, 0, 0, 0, 0, 4, 0, 8 },
                         { 0, 0, 5, 0, 0, 0, 9, 8, 0 }
                            };

            var sd = new SearchDistance();
            var (distance, topCount) = sd.Diikstra(graph, 0, 9);

            Print(distance, topCount);
        }


        //Метод вывода на консоль вершину графа и расстояние
        static void Print(int[] distance, int topCount)
        {
            Console.WriteLine("Вершина      Расстояние от источника");

            for (int i = 0; i < topCount; i++)
            {
                Console.WriteLine("{0}\t\t{1}", i, distance[i]);
            }
        }
    }
}
