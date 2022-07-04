using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorism
{
    class Min_Max
    {
        static void Main(string[] args)
        {
            int[] data = { 6, 7, 1, 2, 4, 5, 9, 8 };

            int min = data[0];
            int max = 0;

            for(int i = 0; i < data.Length; i++)
            {
                //  최솟값 구하는 로직
                if(min > data[i])
                {
                    min = data[i];
                }

                //  최댓값 구하는 로직
                if(max < data[i])
                {
                    max = data[i];
                }
            }

            Console.WriteLine("최솟값 : {0}, 최댓값 : {1}", min, max);
        }
    }
}
