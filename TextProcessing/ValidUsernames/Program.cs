using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .Where(x => x.Length >= 3 && x.Length <= 16)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                for (int k = 0; k < input[i].Length; k++)
                {
                    char symbol = input[i][k];
                    if (!(char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_'))
                    {
                        input = input
                            .Where(x => x != input[i])
                            .ToArray();
                        i--;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}