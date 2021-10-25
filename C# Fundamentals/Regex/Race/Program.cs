using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine().Split(", ");

            Dictionary<string, int> participants = new Dictionary<string, int>();

            foreach (var racer in racers)
            {
                participants.Add(racer, 0);
            }

            string info = Console.ReadLine();

            string namePattern = @"[\W\d]";
            string distancePattern = @"[\D]+";

            while (info != "end of race")
            {
                int sum = 0;
                string name = Regex.Replace(info, namePattern, "");
                string distance = Regex.Replace(info, distancePattern, "");

                if (participants.ContainsKey(name))
                {
                    foreach (char digit in distance)
                    {
                        sum += int.Parse(digit.ToString());
                    }

                    participants[name] += sum;
                }

                info = Console.ReadLine();
            }

            int counter = 1;

            foreach (var item in participants.OrderByDescending(x => x.Value).Take(3))
            {
                string text = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{ counter++}{ text} place: {item.Key}");
            }
        }
    }
}