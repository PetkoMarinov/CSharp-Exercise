using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, int> nums = new Dictionary<string, int>();
            string evenNum = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                string num = Console.ReadLine();

                if (!nums.Keys.Contains(num))
                {
                    nums[num] = 0;
                }

                nums[num]++;

                if (nums[num] % 2 == 0)
                {
                    evenNum = num;
                }
            }

            Console.WriteLine(evenNum);
        }
    }
}