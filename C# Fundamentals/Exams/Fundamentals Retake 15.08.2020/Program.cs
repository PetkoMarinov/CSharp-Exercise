using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"([|#])([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,5})\1");
            MatchCollection foodInfo = regex.Matches(input);
            
            int totalCalories = foodInfo.Sum(x=>int.Parse(x.Groups[4].Value));
            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            
            foreach (Match item in foodInfo)
            {
                string name = item.Groups[2].Value;
                string expexpirationDate= item.Groups[3].Value;
                string calories = item.Groups[4].Value;

                Console.WriteLine($"Item: {name}, Best before: {expexpirationDate}," +
                    $" Nutrition: {calories}");
            }
        }
    }
}
