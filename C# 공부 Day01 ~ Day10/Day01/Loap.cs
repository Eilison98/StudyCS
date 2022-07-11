using System;

namespace Loop
{
    class forLoop
    {
        //  1 ~ 100까지의 합을 구하기
        static void Main(string[] args)
        {
            //  전체 값 초기화
            int sum = 0;

            //  for문을 통하여 1 ~ 100까지 반복하여 sum에 더해준다.
            for (int i = 1; i <= 100; i++)
            {
                sum = sum + i;
            }

            //  전체 합의 값을 대입
            Console.WriteLine("Sum : {0}", sum);
        }
    }
}