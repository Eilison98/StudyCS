using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.Write("Enter Score: ");
                string answer = Console.ReadLine();

                if (answer == "")
                {
                    break;
                }

                int score = int.Parse(answer);

                if (score >= 90)
                {
                    Console.WriteLine("Grade A");
                }
                else if (score >= 80)
                {
                    Console.WriteLine("Grade B");
                }
                else if (score >= 70)
                {
                    Console.WriteLine("Grade C");
                }
                else if (score >= 60)
                {
                    Console.WriteLine("Grade D");
                }
                else
                {
                    Console.WriteLine("Grade F");
                }
            }
        }
    }
}