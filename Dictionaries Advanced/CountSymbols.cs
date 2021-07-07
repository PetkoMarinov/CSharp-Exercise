using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (!symbols.Keys.Contains(symbol))
                {
                    symbols[symbol] = 0;
                }

                symbols[symbol]++;
            }

            foreach (char symbol in symbols.Keys.OrderBy(x=>x))
            {
                Console.WriteLine($"{symbol}: {symbols[symbol]} time/s");
            }
        }
    }
}
