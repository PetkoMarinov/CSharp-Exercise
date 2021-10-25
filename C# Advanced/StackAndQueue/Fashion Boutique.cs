using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int capacity = int.Parse(Console.ReadLine());
            int racks = 1;

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int capacityLeft = capacity;

                while (stack.Count > 0)
                {
                    int singleClothesWeight = stack.Pop();

                    if (capacityLeft >= singleClothesWeight)
                    {
                        capacityLeft -= singleClothesWeight;
                    }
                    else
                    {
                        capacityLeft = capacity;
                        capacityLeft -= singleClothesWeight;
                        racks++;
                    }
                }

                Console.WriteLine(racks);
            }
        }
    }
}
