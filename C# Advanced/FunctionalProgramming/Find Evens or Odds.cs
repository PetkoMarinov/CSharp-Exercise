using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] borders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int lower = borders[0];
            int upper = borders[1];

            string command = Console.ReadLine();

            Predicate<int> evenOrOdd = command == "even" 
                ? x => x % 2 == 0 
                : new Predicate<int> (x => x % 2 != 0); /*x => x % 2 != 0;*/

            List<int> result = new List<int>(upper - lower);
            for (int i = lower; i <= upper; i++)
            {
                if (evenOrOdd(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}