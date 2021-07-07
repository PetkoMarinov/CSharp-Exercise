using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigString = Console.ReadLine().TrimStart('0');
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                goto Finish;
            }

            StringBuilder sb = new StringBuilder();
            int inMind = 0;

            for (int i = bigString.Length - 1; i >= 0; i--)
            {
                int firstNum = (int)char.GetNumericValue(bigString[i]);

                int product = (firstNum * secondNum) + inMind;
                
                sb.Insert(0, product % 10); //add second digit ot product at first place
                inMind = product / 10;
            }

            if (inMind > 0)
            {
                sb.Insert(0, inMind);
            }

            Console.WriteLine(sb);

        Finish:
            ;
        }
    }
}
