using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (sb[i] == sb[i + 1])
                {
                    sb.Remove(i + 1, 1);
                    i--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
