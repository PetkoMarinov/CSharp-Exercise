using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandLine = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandLine[0];
                int rowIndex = int.Parse(commandLine[1]);
                int colIndex = int.Parse(commandLine[2]);
                int value = int.Parse(commandLine[3]);

                bool validRow = rowIndex <= rows - 1 && rowIndex >= 0;
                bool validCol = validRow == true ?
                    colIndex <= matrix[rowIndex].Length - 1 && colIndex >= 0 : false;

                if (validRow && validCol)
                {
                    if (command == "Add")
                    {
                        matrix[rowIndex][colIndex] += value;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[rowIndex][colIndex] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (double[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
