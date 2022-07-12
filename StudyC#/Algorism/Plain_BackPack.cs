/*
 * 
 * 평범한 배낭  /  백준 12865
 * 
 * 
 *  문제  *
 *  ======================================================================================================================================================= *
 * 이 문제는 아주 평범한 배낭에 관한 문제이다.
 * 한 달 후면 국가의 부름을 받게 되는 준서는 여행을 가려고 한다. 세상과의 단절을 슬퍼하며 최대한 즐기기 위한 여행이기 때문에,
 * 가지고 다닐 배낭 또한 최대한 가치 있게 싸려고 한다.
 * 준서가 여행에 필요하다고 생각하는 N개의 물건이 있다. 각 물건은 무게 W와 가치 V를 가지는데, 해당 물건을 배낭에 넣어서 가면 준서가 V만큼 즐길 수 있다. 
 * 아직 행군을 해본 적이 없는 준서는 최대 K만큼의 무게만을 넣을 수 있는 배낭만 들고 다닐 수 있다. 
 * 준서가 최대한 즐거운 여행을 하기 위해 배낭에 넣을 수 있는 물건들의 가치의 최댓값을 알려주자.
 *  ======================================================================================================================================================= *
 *  
 *  알고리즘 분류  *
 *  - 다이나믹 프로그래밍
 *  - 배낭 문제
 *  
 */

using System;
using System.IO;
namespace Program
{
    class Plain_BackPack
    {
        static void Main(string[] args)
        {
            //  OpenStandardInput && OpenStandardOutput 은 표출 입력 / 출력 스트림이다.
            StreamReader sr = new StreamReader(Console.OpenStandardInput());            //  파일에서 텍스트를 읽어온값을 sr에 저장한다.
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());           //  텍스트를 파일에 출력하며 sw에 저장한다.
            string[] arr = sr.ReadLine().Split();                                       //  1차원 배열에 sr에서 읽어온 값을 공백과 함께 저장한다.
            int n = int.Parse(arr[0]), weight = int.Parse(arr[1]);  // Parse을 사용하여 n과 weight를 int형으로 arr[]배열에 각각 저장한다.
            int[,] dp = new int[n + 1, weight + 1];

            for (int i = 1; i <= n; i++)
            {
                arr = sr.ReadLine().Split();
                int w = int.Parse(arr[0]);
                int value = int.Parse(arr[1]);
                for (int j = 1; j <= weight; j++)
                {
                    if (w <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - w] + value);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }

                }
            }
            sw.Write(dp[n, weight]);
            sw.Close();
        }
    }
}