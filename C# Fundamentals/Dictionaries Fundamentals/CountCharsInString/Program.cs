using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (countChars.ContainsKey(item[i]))
                    {
                        countChars[item[i]] += 1;
                    }
                    else
                    {
                        countChars.Add(item[i], 1);
                    }
                }
            }

            foreach (var item in countChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
