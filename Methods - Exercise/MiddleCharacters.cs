using System;

namespace MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(MiddleElements(input));
        }

        static string MiddleElements(string text)
        {
            int middle = text.Length / 2;
            if (text.Length%2==0)
            {
                return text[middle-1].ToString() + text[middle].ToString();
            }
            else
            {
                return text[middle].ToString();
            }
        }
    }
}