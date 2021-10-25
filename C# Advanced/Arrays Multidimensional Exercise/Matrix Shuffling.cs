using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandLine = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandLine[0] == "swap" & commandLine.Length == 5)
                {
                    int row1 = int.Parse(commandLine[1]);
                    int col1 = int.Parse(commandLine[2]);
                    int row2 = int.Parse(commandLine[3]);
                    int col2 = int.Parse(commandLine[4]);

                    bool validRows = row1 <= rows - 1 && row2 <= rows - 1 && row1 >= 0 && row2 >= 0;
                    bool validCols = col1 <= cols - 1 && col2 <= cols - 1 && col1 >= 0 && col2 >= 0;

                    if (validRows && validCols)
                    {
                        string changedValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = changedValue;
                        Print(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
