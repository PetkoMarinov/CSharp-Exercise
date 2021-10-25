using System;
using System.Text.RegularExpressions;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"[^@ ,]\w+[^@ ,]-?[^@ ,]\w+[^@ ,]";

            MatchCollection validNames = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join("\n",validNames));




        }
    }
}
