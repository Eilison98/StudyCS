using System;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            int b = 200;

            int result = Add(a, b);
            Console.WriteLine(result);

            result = Substract(a, b);
            Console.WriteLine(result);
        }

        //  두 정수를 더하는 메서드
        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        //  두 정수를 빼는 메서드
        static int Substract(int a, int b)
        {
            int c = a - b;
            return c;
        }
    }
}