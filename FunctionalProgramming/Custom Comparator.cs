using System;
using System.Linq;

namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int, int, int> comparer = (num1, num2) =>
                  (num1 % 2 == 0 && num2 % 2 != 0) ? -1 :
                  (num1 % 2 != 0 && num2 % 2 == 0) ? 1 : num1.CompareTo(num2);

            Array.Sort(numbers, new Comparison<int>(comparer));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}