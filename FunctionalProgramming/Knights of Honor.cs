using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine("Sir " + x);
            string[] text = Console.ReadLine().Split();

            foreach (var word in text)
            {
                print(word);
            }
        }
    }
}
