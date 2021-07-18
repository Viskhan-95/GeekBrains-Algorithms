using System;
using System.Collections.Generic;
using System.Text;

namespace DZ6
{
    class SearchDistance
    {
        // Метод поиска минимального расстояния
        private int MinDistance(int[] distance, bool[] shortsPaths, int topCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < topCount; i++)
            {
                if (shortsPaths[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }


        //Метод поиска кратчайшего пути по алгоритму Дейкстра
        /*Чтоб метод не выводил инфо на консоль, а возврашал данные, решил использовать кортеж 
        не знаю грамотно ли использовать кортеж */
        public (int[], int) Diikstra(int[,] graph, int source, int topCount)
        {
            int[] distance = new int[topCount];
            bool[] shortsPaths = new bool[topCount];

            for (int i = 0; i < topCount; i++)
            {
                distance[i] = int.MaxValue;
                shortsPaths[i] = false;
            }

            distance[source] = 0;

            for (int i = 0; i < topCount - 1; i++)
            {
                int minDistance = MinDistance(distance, shortsPaths, topCount);
                shortsPaths[minDistance] = true;

                for (int j = 0; j < topCount; j++)
                    /*Условие слишком громоздкое, в связи с чем думал разбить на под условии
                     * для читабельности */
                    if (!shortsPaths[j] && Convert.ToBoolean(graph[minDistance, j]) && distance[minDistance] != int.MaxValue && distance[minDistance] + graph[minDistance, j] < distance[j])
                        distance[j] = distance[minDistance] + graph[minDistance, j];
            }

            return (distance, topCount);
        }
    }
}
