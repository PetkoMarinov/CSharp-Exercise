using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = Console.ReadLine();

            while (input!="END")
            {
                string []actionData = input.Split(" ");
                string command = actionData[0];
                int row = int.Parse(actionData[1]);
                int col = int.Parse(actionData[2]);
                int value = int.Parse(actionData[3]);

                if (row < 0 || row >= jagged.Length 
                    || col < 0 || col >= jagged.Length)
                { Console.WriteLine("Invalid coordinates"); }
                else
                {
                    switch (command)
                    {
                        case "Add": jagged[row][col] += value; break;
                        case "Subtract": jagged[row][col] -= value; break;
                    }
                }

                input = Console.ReadLine();
            }

            for (int r = 0; r < jagged.Length; r++)
            {
                for (int c = 0; c < jagged[r].Length; c++)
                {
                    Console.Write(jagged[r][c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
