using System;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int divisibleNum = int.Parse(Console.ReadLine());

            Predicate<int> isNotDivisible = x => x % divisibleNum != 0;

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            numbers = numbers.Where(x => isNotDivisible(x)).Reverse().ToArray();
            print(numbers);
        }
    }
}