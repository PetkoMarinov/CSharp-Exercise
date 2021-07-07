using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(@"C:\Users\сем. Маринови\Desktop\ДДС\CSharp\words.txt");
            string text = File.ReadAllText(@"C:\Users\сем. Маринови\Desktop\ДДС\CSharp\text.txt");

            MatchCollection matches = Regex.Matches(text, "([A-z])+");

            for (int i = 0; i < words.Length; i++)
            {
                int count = matches
                  //  .Cast<Match>()
                    .Select(x => x.ToString().ToLower())
                    .Where(x => x == words[i])
                    .ToArray().Length;

                words[i] = $"{words[i]} - {count}";
            }

            File.WriteAllLines("actualResults.txt.", words);

            words = words.OrderByDescending(x => x.ElementAt(x.Length - 1)).ToArray();
            File.WriteAllLines("expectedResult.txt.", words);
        }
    }
}
