using System;

namespace A006_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;     //  int형
            double x;  //  실수형

            i = 5;
            x = 3.141592;
            Console.WriteLine("i = " + i + ", x = " + x);

            x = i;       //  암시적 형변환
            i = (int)x;  //  캐스트가 필요함
            Console.WriteLine("i = " + i + ", x = " + x);
        }
    }
}
