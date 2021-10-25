using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> result = new Dictionary<string, int>();

            while (input!="stop")
            {
                string source = input;
                int quantity = int.Parse(Console.ReadLine());

                if (result.ContainsKey(source))
                {
                    result[source] += quantity;
                }
                else
                {
                    result[source] = quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
