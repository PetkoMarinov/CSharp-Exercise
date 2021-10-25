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

            string emojiPattern = @"(\:{2}|\*{2})([A-Z][a-z]{2,})\1";
            string numbersPattern = @"\d";

            MatchCollection matches = Regex.Matches(input, emojiPattern);
            int treshold = Regex.Matches(input, numbersPattern)
                .Cast<Match>()
                .Select(x => int.Parse(x.Value))
                .ToArray()
                .Aggregate(1, (a, b) => a * b);

            List<string> emojiList = new List<string>();
            //string[] emojiList = matches
            //    .Cast<Match>()
            //    .Select(x => x.Value)
            //    .ToArray();

            foreach (Match item in matches)
            {
                int sum = 0;
                string emoji = item.Groups[2].Value;

                for (int i = 0; i < emoji.Length; i++)
                {
                    char letter = item.Groups[2].Value[i];
                    sum += letter;
                }

                if (sum >= treshold)
                {
                    //emojiList = emojiList
                    //    .Where(x => x != item.Value)
                    //    .ToArray();
                    emojiList.Add(item.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {treshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            Console.Write(string.Join("\n", emojiList));
        }
    }
}