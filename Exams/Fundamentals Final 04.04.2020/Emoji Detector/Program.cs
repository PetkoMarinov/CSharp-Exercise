using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var test = Regex.Matches(input, @"\d");
            var treshold = Regex.Matches(input, @"\d")
                .Cast<Match>()
                .Select(x => int.Parse(x.Value))
                .ToArray()
                .Aggregate(1, (a, b) => a * b);

            var matches = Regex.Matches(input, @"(?:(:{2}|\*{2}))([A-Z][a-z]{2,})\1");

            Console.WriteLine($"Cool threshold: {treshold}");

            Dictionary<string, int> emojies = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                string emoji = match.Groups[2].Value;
                emojies[match.Value] = emoji.ToCharArray().Aggregate(1, (a, b) => a + b);
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} emojis found in the text." +
                    $" The cool ones are:");

                emojies.Where(x => x.Value >= treshold)
                    .Select(x => x.Key)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));
            }
        }
    }
}
