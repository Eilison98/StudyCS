using System;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int score1 = 70;
            int score2 = 80;
            int score3 = 88;
            int score4 = 90;
            int score5 = 75;
            int score6 = 72;
            int score7 = 82;
            int score8 = 85;
            int score9 = 95;
            int score10 = 72;

            int sum = score1 + score2 + score3 + score4 + score5 +
                      score6 + score7 + score8 + score9 + score10;

            Console.WriteLine(sum);
        }
    }
}


//  간단하게 사용한다면  //
/*
   using System;

  namespace Day3
  {
      class Program
      {
          static void Main(string[] args)
          {
              int[] score = new int[10] { 70, 80, 88, 90, 75, 72, 82, 85, 95, 72 };

              int sum = 0;
              for (int i = 0; i < score.Length; i++)
              {
                  sum += score[i];
              }

              Console.WriteLine(sum);
          }
      }
  }
 */