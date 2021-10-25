using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\сем. Маринови\Desktop\ДДС\CSharp\text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                Regex regex = new Regex("['.,-?!]");
                MatchCollection matches = regex.Matches(lines[i]);

                int lineLength = lines[i]
                    .Where(x => char.IsLetter(x))
                    .ToArray().Length;
                lines[i] = $"Line {i + 1}: {lines[i]} ({lineLength})({matches.Count})";
            }

            File.WriteAllLines("Output.txt", lines);
        }
    }
}
