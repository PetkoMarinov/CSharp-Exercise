using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rowKey = Console.ReadLine();
            string input = Console.ReadLine();
            string activationKey = rowKey;

            while (input != "Generate")
            {
                string[] instructions = input.Split(">>>");
                string command = instructions[0];

                switch (command)
                {
                    case "Contains":
                        string substring = instructions[1];

                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;

                    case "Flip":
                        string upperOrLower = instructions[1];
                        int startIndex = int.Parse(instructions[2]);
                        int endIndex = int.Parse(instructions[3]);
                        int length = endIndex - startIndex;
                        string extract = activationKey.Substring(startIndex, length);

                        extract = (upperOrLower == "Upper")
                            ? extract = extract.ToUpper()
                            : extract = extract.ToLower();

                        activationKey = activationKey.Replace(extract, extract
                            , StringComparison.OrdinalIgnoreCase);

                        Console.WriteLine(activationKey);
                        break;

                    case "Slice":
                        int start = int.Parse(instructions[1]);
                        int end = int.Parse(instructions[2]);

                        // activationKey = activationKey.Remove(start, end - start);
                        string ToRemove = activationKey.Substring(start, end - start);
                        activationKey = activationKey.Replace(ToRemove, new string(""));
                        Console.WriteLine(activationKey);
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}