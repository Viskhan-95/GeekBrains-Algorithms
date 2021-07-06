using System;

namespace DZ2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static int Search(int[] array, int searchValue)
        {
            int min = 0; // O(1)
            int max = array.Length - 1; // O(1)

            while (min <= max) // O(N)
            {
                int mid = (min + max) / 2; 
                
                if (searchValue == array[mid])
                {
                    return mid;
                }
                
                else if (searchValue < array[mid])
                {
                    max = mid - 1;
                }
                
                else
                {
                    min = mid + 1;
                }
            }
            return -1; // O(1)
            // Асимптотическая сложность данного метода равна O(N)
        }
    }
}
