using System;

namespace A008_ConsoleWriteMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10 이하의 소수: {0}, {1}, {2}, {3}", 2, 3, 5, 7);

            //  Format :  지정한 개체의 텍스트 표현을 콘솔에 출력합니다.
            //  string.Format() : 콘솔에 출력하는 것과 똑같이 문자열에 저장할 수도 있습니다.
            string primes;
            primes = string.Format("10 이하의 소수: {0}, {1}, {2}, {3}", 2, 3, 5, 7);
            Console.WriteLine(primes);
        }
    }
}
