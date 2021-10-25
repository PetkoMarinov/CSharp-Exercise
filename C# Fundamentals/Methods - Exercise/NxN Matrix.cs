using System;

namespace NxNMatrix
{
    class NxNMatrix
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintMatrix(input);
        }

        static void PrintMatrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                int counter = num;
                while (counter > 0)
                {
                    Console.Write(num + " ");
                    counter--;
                }
                Console.WriteLine();
            }
        }
    }
}