using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = array =>
            {
                int min = int.MaxValue;

                foreach (var num in array)
                {
                    if (min > num)
                    {
                        min = num;
                    }
                }

                return min;
            };

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(minNum(nums));
        }
    }
}