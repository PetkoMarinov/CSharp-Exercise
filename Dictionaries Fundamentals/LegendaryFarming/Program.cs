using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class LegendaryItems
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                { "motes",0 },
                {"shards",0 },
                {"fragments",0 }
            };

            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            string winnerItem = string.Empty;
            bool isRunning = true;

            while (isRunning)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int itemValue = int.Parse(input[i]);
                    string item = input[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += itemValue;

                        if (legendaryItems[item] >= 250)
                        {
                            legendaryItems[item] -= 250;
                            winnerItem = item;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += itemValue;
                        }
                        else
                        {
                            junkItems[item] = itemValue;
                        }
                    }
                }
            }

            if (winnerItem == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
            else if (winnerItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else
            {
                Console.WriteLine("Valanyr obtained!");
            }

            legendaryItems = legendaryItems
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var element in legendaryItems)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }

            junkItems = junkItems
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in junkItems)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }

        }
    }
}