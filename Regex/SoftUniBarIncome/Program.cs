using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftuniBar
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$$";

            double turnover = 0;

            while (input != "end of shift")
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match item in matches)
                {
                    string customer = item.Groups[1].Value;
                    string product = item.Groups[2].Value;
                    int quantity = int.Parse(item.Groups[3].Value);
                    double price = double.Parse(item.Groups[4].Value);

                    double bill = quantity * price;
                    turnover += bill;
                    Console.WriteLine($"{customer}: {product} - {bill:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {turnover:f2}");
        }
    }
}