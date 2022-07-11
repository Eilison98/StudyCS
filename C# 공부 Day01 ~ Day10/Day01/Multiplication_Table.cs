using System;

namespace Multiplication_Table
{
    //  구구단 2 ~ 9단까지
    class Program
    {
        static void Main(string[] args)
        {
            //  * 순서가 중요 *
            //  for문을 이용하여 2 ~ 9까지 반복
            for (int i = 2; i < 10; i++)
            {
                //  for문을 이용하여 1 ~ 9까지 반복
                for (int j = 1; j < 10; j++)
                {
                    //  {0}자리에 i, {1}자리에 j, {2}자리에 i * j 대입
                    Console.WriteLine("{0} X {1} = {2}", i, j, i * j);
                }
            }
        }
    }
}