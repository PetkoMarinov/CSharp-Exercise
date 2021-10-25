using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            Func<string, int[], int[]> arithmeticFunc = (str, numbers) =>
              {
                  switch (str)
                  {
                      case "add": numbers = numbers.Select(x => x + 1).ToArray(); break;
                      case "multiply": numbers = numbers.Select(x => x * 2).ToArray(); ; break;
                      case "subtract": numbers = numbers.Select(x => x - 1).ToArray(); break;
                      case "print": print(numbers); break;
                  }
                  return numbers;
              };

            string command = Console.ReadLine();
            while (command != "end")
            {
                numbers = arithmeticFunc(command, numbers);
                command = Console.ReadLine();
            }
        }
    }
}