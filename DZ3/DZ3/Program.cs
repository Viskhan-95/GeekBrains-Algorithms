using System;
using System.Diagnostics;

namespace DZ3
{
    class Program
    {
        static class TestMethods
        {
            public static double GetTime(Action act)
            {
                Stopwatch sw;
                double[] listTime = new double[10];
                double midTime = 0;
                for (int i = 0; i < 10; i++)
                {
                    sw = new Stopwatch();
                    sw.Start();
                    act();
                    sw.Stop();
                    listTime[i] = sw.ElapsedTicks; //При ElapsedMilliseconds время 0,1 или 0 трудно увидит различие
                }

                for (int i = 0; i < listTime.Length; i++) midTime += listTime[i];

                return midTime / listTime.Length;
            }
        }


        public class PointClass
        {
            public float X { get; set; }
            public float Y { get; set; }

            public PointClass(float x, float y)
            {
                X = x;
                Y = y;
            }
        }


        public struct PointStruct
        {
            public float X { get; set; }
            public float Y { get; set; }

            public PointStruct (float x, float y)
            {
                X = x;
                Y = y;
            }
        }


        public static float PointDistanceFloat(PointClass pointFirst, PointClass pointSecond)
        {
            float x = pointSecond.X - pointFirst.X;
            float y = pointSecond.Y - pointFirst.Y;
            return (float)Math.Sqrt((x*x) + (y*y));
        }


        public static float PointDistanceFloat(PointStruct pointFirst, PointStruct pointSecond)
        {
            float x = pointSecond.X - pointFirst.X;
            float y = pointSecond.Y - pointFirst.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }


        public static double PointDistanceDouble(PointStruct pointFirst, PointStruct pointSecond)
        {
            double x = pointSecond.X - pointFirst.X;
            double y = pointSecond.Y - pointFirst.Y;
            return Math.Sqrt((x * x) + (y * y));
        }


        public static float PointDistanceFloatNoMathSqrt(PointStruct pointFirst, PointStruct pointSecond)
        {
            float x = pointSecond.X - pointFirst.X;
            float y = pointSecond.Y - pointFirst.Y;

            float number = (x * x) + (y * y);
            float t;
            float sqrtRoot = number / 2;

            do
            {
                t = sqrtRoot;
                sqrtRoot = (t + (number / t)) / 2;
            }
            while ((t - sqrtRoot) != 0);

            return sqrtRoot;
        }


        static void Main(string[] args)
        {
            Random rnd = new Random();
            //Беру большие числа, в связи с тем, что на маленьких числах времени не заметить
            int[] distance = new int[] { rnd.Next(800_000_000, 900_000_000), rnd.Next(800_000_000, 900_000_000), rnd.Next(900_000_000, 1_000_000_000), rnd.Next(900_000_000, 1_000_000_000) };

            double midTime = 0;
            midTime = TestMethods.GetTime(() => PointDistanceFloat(new PointClass(distance[0], distance[1]), new PointClass(distance[2], distance[3])));

            Console.WriteLine($"           Method            | Time");
            Console.WriteLine($"-----------------------------|-----");
            Console.WriteLine($"PointDistanceFloatClass      | {midTime}");

            midTime = 0;
            midTime = TestMethods.GetTime(() => PointDistanceFloat(new PointStruct(distance[1], distance[0]), new PointStruct(distance[3], distance[2])));

            Console.WriteLine($"PointDistanceFloatStruct     | {midTime}");

            midTime = 0;
            midTime = TestMethods.GetTime(() => PointDistanceDouble(new PointStruct(distance[1], distance[0]), new PointStruct(distance[3], distance[2])));

            Console.WriteLine($"PointDistanceDoubleStruct    | {midTime}");


            midTime = 0;
            midTime = TestMethods.GetTime(() => PointDistanceFloatNoMathSqrt(new PointStruct(distance[1], distance[0]), new PointStruct(distance[3], distance[2])));

            Console.WriteLine($"PointDistanceFloatNoMathSqrt | {midTime}");
        }
    }
}
