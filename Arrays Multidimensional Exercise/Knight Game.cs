using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        class Knight
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Power { get; set; }

            public Knight(int row, int col, int power)
            {
                this.Row = row;
                this.Column = col;
                this.Power = power;
            }
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] chessBoard = new char[size][];

            for (int row = 0; row < size; row++)
            {
                chessBoard[row] = Console.ReadLine().ToCharArray();
            }

            int removed = 0;

            List<Knight> attackers = KnightsAttackers(chessBoard);

            while (attackers.Count > 0)
            {
                int row = attackers[0].Row;
                int col = attackers[0].Column;
                chessBoard[row][col] = '0';
                removed++;
                attackers = KnightsAttackers(chessBoard);
            }

            Console.WriteLine(removed);
        }

        static List<Knight> KnightsAttackers(char[][] chessBoard)
        {
            List<Knight> knights = new List<Knight>();

            int size = chessBoard.GetLength(0);

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard[row].Length; col++)
                {
                    bool knightMove1 = row + 1 <= size - 1 && col + 2 <= size - 1;
                    bool knightMove2 = row + 1 <= size - 1 && col - 2 >= 0;
                    bool knightMove3 = row + 2 <= size - 1 && col + 1 <= size - 1;
                    bool knightMove4 = row + 2 <= size - 1 && col - 1 >= 0;
                    bool knightMove5 = row - 1 >= 0 && col + 2 <= size - 1;
                    bool knightMove6 = row - 1 >= 0 && col - 2 >= 0;
                    bool knightMove7 = row - 2 >= 0 && col + 1 <= size - 1;
                    bool knightMove8 = row - 2 >= 0 && col - 1 >= 0;

                    int knightPower = new bool[]
                    {
                        chessBoard[row][col]=='K' && knightMove1 && chessBoard[row+1][col+2]=='K',
                        chessBoard[row][col]=='K' && knightMove2 && chessBoard[row+1][col-2]=='K',
                        chessBoard[row][col]=='K' && knightMove3 && chessBoard[row+2][col+1]=='K',
                        chessBoard[row][col]=='K' && knightMove4 && chessBoard[row+2][col-1]=='K',
                        chessBoard[row][col]=='K' && knightMove5 && chessBoard[row-1][col+2]=='K',
                        chessBoard[row][col]=='K' && knightMove6 && chessBoard[row-1][col-2]=='K',
                        chessBoard[row][col]=='K' && knightMove7 && chessBoard[row-2][col+1]=='K',
                        chessBoard[row][col]=='K' && knightMove8 && chessBoard[row-2][col-1]=='K',
                    }
                        .Count(x => x == true);

                    if (knightPower > 0)
                    {
                        knights.Add(new Knight(row, col, knightPower));
                    }

                }
            }
            knights = knights.OrderByDescending(x => x.Power).ToList();
            return knights;
        }
    }
}