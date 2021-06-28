using System;

namespace DZ1._2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; //O(1)

                        //В методичке блок "условие (if)" пренебрегается, хотелось бы узнать почему? 
                        //Почему не O(1)?
                        if (j != 0) 
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1)
                    }
                }
            }

            return sum;  //O(1)
        }

        /*Асимптоматическая сложность данного метода O(4 + N*N*N)
         * Учитывая правило 3 - O(N*N*N) или O(N^3)
         */
    }
}
