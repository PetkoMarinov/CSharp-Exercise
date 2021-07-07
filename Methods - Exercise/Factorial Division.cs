using System;
using System.Numerics;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"{FactorialDivide(firstNum, secondNum):f2}");
        }

        static double FactorialDivide(int firstNum, int secondNum)
        {
            BigInteger firstFactorial = 1;
            BigInteger secondFactorial = 1;

            for (int i = 1; i <= firstNum; i++)
            {
                firstFactorial *= i;
            }

            for (int i = 1; i <= secondNum; i++)
            {
                secondFactorial *= i;
            }

            return (double)firstFactorial / (double)secondFactorial;
        }
    }
}
