using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>([A-z]+)<<(\d+\.?\d+)!(\d+)";

            double sum = 0;

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match item in matches)
                {
                    string name = item.Groups[1].Value;
                    double price = double.Parse(item.Groups[2].Value);
                    int quantity = int.Parse(item.Groups[3].Value);

                    sum += price * quantity;
                    Console.WriteLine(name);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}