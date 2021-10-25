using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string foodData = Console.ReadLine();

            string pattern = @"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";

            MatchCollection matches = Regex.Matches(foodData, pattern);

            int food = 0;

            foreach (Match item in matches)
            {
                food += int.Parse(item.Groups["calories"].Value);
            }

            int days = food / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match meal in matches)
            {
                int calories = int.Parse(meal.Groups["calories"].Value);
                string item = meal.Groups["name"].Value;
                string expDate = meal.Groups["date"].Value;

                Console.WriteLine($"Item: { item}, Best before: {expDate}," +
                    $" Nutrition: { calories}");
            }
        }
    }
}
