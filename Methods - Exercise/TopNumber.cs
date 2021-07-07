using System;

namespace TopInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            for (int i = 1; i <= upperBound; i++)
            {
                PrintTop(i);
            }
        }

        static void PrintTop(int num)
        {
            int sum = 0;
            bool isOdd = false;

            for (int i = 0; i < num.ToString().Length; i++)
            {
                if (num.ToString()[i] % 2 != 0)
                {
                    isOdd = true;
                }
                sum += num.ToString()[i];
            }

            if (isOdd && sum % 8 == 0)
            {
                Console.WriteLine(num);
                return;
            }

            return;
        }
    }
}

