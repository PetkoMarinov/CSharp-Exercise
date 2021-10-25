using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int leftSum = 0;
            int rightSum = 0;

            for (int row = 0; row < size; row++)
            {
                leftSum += matrix[row, row];

                for (int col = size - row - 1; col >= 0; col--)
                {
                    rightSum += matrix[row, col]; break;
                }
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}