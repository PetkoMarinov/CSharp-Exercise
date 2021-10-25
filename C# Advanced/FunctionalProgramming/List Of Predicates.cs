using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] deviders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int, bool> filter = (deviders, number) => deviders.All(x => number % x == 0);
            //{
            //    //bool isDevisible = true;

            //    //for (int i = 0; i < deviders.Length; i++)
            //    //{
            //    //    if (number % deviders[i] != 0)
            //    //    {
            //    //        isDevisible = false;
            //    //        break;
            //    //    }
            //    //}
            //    //return isDevisible;
            //};

            int[] result = Enumerable.Range(1, endOfRange).Where(x => filter(deviders, x)).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}