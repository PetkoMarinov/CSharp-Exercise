using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] colourInput = Console.ReadLine().Split(" -> ");
                string[] clothes = colourInput[1].Split(',');

                for (int k = 0; k < clothes.Length; k++)
                {
                    string colour = colourInput[0];
                    string dress = clothes[k];

                    if (!wardrobe.Keys.Contains(colour))
                    {
                        wardrobe[colour] = new Dictionary<string, int>();
                    }

                    if (!wardrobe[colour].ContainsKey(dress))
                    {
                        wardrobe[colour][dress] = 0;
                    }

                    wardrobe[colour][dress]++;
                }
            }

            string[] lookFor = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var dress in colour.Value)
                {
                    Console.Write($"* {dress.Key} - {dress.Value}");

                    if (colour.Key == lookFor[0] && dress.Key == lookFor[1])
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }