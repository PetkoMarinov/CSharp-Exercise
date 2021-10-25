using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            Queue<string> snake = new Queue<string>(Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        string element = snake.Dequeue();
                        matrix[row, col] = element;
                        snake.Enqueue(element);
                    }
                    else
                    {
                        for (int i = matrix.GetLength(1)-1; i >=0; i--)
                        {
                            string element = snake.Dequeue();
                            matrix[row, i] = element;
                            snake.Enqueue(element);
                        }
                        break;
                    }

                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}