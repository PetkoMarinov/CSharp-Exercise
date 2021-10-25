using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ');

            Func<string[], string[]> print = text =>
            {
                text = text.Where(x => x.Length <= length).ToArray();
                Console.WriteLine(string.Join("\n", text));
                return text;
            };

            print(names);
        }
    }
}