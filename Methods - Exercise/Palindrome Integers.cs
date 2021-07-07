using System;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END".ToUpper())
            {
                Console.WriteLine(IsPalindrome(input));
                input = Console.ReadLine();
            }

        }

        static bool IsPalindrome(string inputStr)
        {
            string temp = inputStr.ToString();

            for (int i = 0; i < temp.Length / 2; i++)
            {
                if (temp[i] != temp[temp.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
