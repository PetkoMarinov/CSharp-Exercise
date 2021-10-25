using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < arr.Length; k++)
                {
                    set.Add(arr[k]);
                }
            }

            Console.WriteLine(string.Join(" ",set.OrderBy(x=>x)));
        }
    }
}