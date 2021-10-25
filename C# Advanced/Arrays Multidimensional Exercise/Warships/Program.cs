using System;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            string[][] battleField = new string[size][];

            for (int row = 0; row < size; row++)
            {
                battleField[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            int shipsPlayerOne = ShipsCount(battleField, "<");
            int shipsPlayerTwo = ShipsCount(battleField, ">");
            int shipsLeftPlayerOne = shipsPlayerOne;
            int shipsLeftPlayerTwo = shipsPlayerTwo;

            for (int i = 0; i < commands.Length; i++)
            {
                if (shipsLeftPlayerOne <= 0 || shipsLeftPlayerTwo <= 0)
                {
                    break;
                }

                int row = int.Parse(commands[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(commands[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                if (row < 0 || row >= size || col < 0 || col >= battleField[row].Length)
                {
                    continue;
                }

                string hit = battleField[row][col];
                string turn = i % 2 == 0 ? "PlayerOne" : "PlayerTwo";

                switch (hit)
                {
                    case "#":
                        battleField = Explosion(battleField, row, col);
                        shipsLeftPlayerOne = ShipsCount(battleField, "<");
                        shipsLeftPlayerTwo = ShipsCount(battleField, ">"); break;
                    //  PrintMatrix(battleField); break;
                    case "<":
                        if (turn == "PlayerTwo")
                        {
                            battleField[row][col] = "X";
                            shipsLeftPlayerOne--;
                        }
                        break;

                    //   PrintMatrix(battleField); break;
                    case ">":
                        if (turn == "PlayerOne")
                        {
                            battleField[row][col] = "X";
                            shipsLeftPlayerTwo--;
                        }
                        break;
                        //     PrintMatrix(battleField); break;
                }
            }

            string winner =
                shipsLeftPlayerOne > 0 && shipsLeftPlayerTwo > 0
                ? "draw" : shipsLeftPlayerOne > shipsLeftPlayerTwo ? "One" : "Two";

            if (winner != "draw")
            {
                int totalShipsDestroyed =
                    shipsPlayerOne + shipsPlayerTwo - shipsLeftPlayerOne - shipsLeftPlayerTwo;
                Console.WriteLine($"Player {winner} has won the game!" +
                    $" {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsLeftPlayerOne} " +
                    $"ships left. Player Two has {shipsLeftPlayerTwo} ships left.");
            }

        }

        static string[][] Explosion(string[][] matrix, int rowIndex, int colIndex)
        {
            int length = matrix.GetLength(0);

            for (int row = rowIndex - 1; row <= rowIndex + 1; row++)
            {
                for (int col = colIndex - 1; col <= colIndex + 1; col++)
                {
                    if (row >= 0 && row < length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] = "X";
                    }
                }
            }
            return matrix;
        }

        static int ShipsCount(string[][] battleField, string type)
        {
            int ships = 0;
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                foreach (var ship in battleField[row])
                {
                    if (ship == type)
                    {
                        ships++;
                    }
                }
            }
            return ships;
        }

        static void PrintMatrix(string[][] matrix)
        {
            Console.WriteLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{ string.Join(" ", matrix[row][col])} ");
                }
                Console.WriteLine();
            }
        }
    }
}