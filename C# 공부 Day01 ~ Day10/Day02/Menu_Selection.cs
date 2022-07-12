/*
치즈버거, 햄버거, 치킨버거, 베지버거 등 4개의 메뉴를 보여주고 사용자로부터 메뉴를 선택하게 하고, 사용자가 특정 메뉴를 입력하면,
해당 버거의 가격을 출력하는 프로그램을 작성해 보자. 이 콘솔 프로그램은 무한히 반복되게 작성하는데, 입력시 Q를 치면 루프를 빠져나오게 한다.
 */

using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                Console.WriteLine();
                Console.WriteLine("******** Menu ********");
                Console.WriteLine();
                Console.WriteLine("1. Cheese burger");
                Console.WriteLine("2. Ham burger");
                Console.WriteLine("3. Chicken burger");
                Console.WriteLine("4. Veggie burger");
                Console.WriteLine();

                Console.Write("Your Choice (Q to Quit) ==> ");
                string answer = Console.ReadLine();

                Console.WriteLine();

                if (answer == "Q" || answer == "q")
                {
                    break;
                }

                else if (answer == "1")
                {
                    Console.WriteLine("Cheese burger : $7.99");
                }

                else if (answer == "2")
                {
                    Console.WriteLine("Ham burger : $6.99");
                }

                else if (answer == "3")
                {
                    Console.WriteLine("Chicken burger : $8.99");
                }

                else if (answer == "4")
                {
                    Console.WriteLine("Veggie burger : $6.00");
                }

                else
                {
                    Console.WriteLine("Error : Invalid Input");
                }
            }
        }
    }
}