using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            Element<int> newList = new Element<int>(list);

            int[] command = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            newList.Swap(list, command[0], command[1]);
            Console.WriteLine(newList);
        }

    }
}
