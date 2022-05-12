using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Gen01(arr, 0);
        }

        static void Gen01(int[] vector, int index)
        {
            if (index >= vector.Length)
                Console.WriteLine(string.Join(" ", vector));
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(vector, index + 1);
                }
            }
        }
    }
}
