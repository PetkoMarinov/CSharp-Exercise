using System;
using System.Collections.Generic;

namespace _1._Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                boxes.Add(box);
            }

            Console.WriteLine(string.Join(Environment.NewLine, boxes));
        }
    }
}
