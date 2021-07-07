using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                int command = int.Parse(input[0].ToString());

                if (command == 1)
                {
                    int number = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    stack.Push(number);
                }
                else if (stack.Count > 0)
                {
                    if (command == 2)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Stack<int> temp = new Stack<int>(stack);
                        int min = int.MaxValue;
                        int max = int.MinValue;

                        while (temp.Count > 0)
                        {
                            int element = temp.Pop();
                            if (min > element)
                            {
                                min = element;
                            }

                            if (max < element)
                            {
                                max = element;
                            }
                        }

                        if (command == 3)
                        {
                            Console.WriteLine(max);
                        }
                        else if (command == 4)
                        {
                            Console.WriteLine(min);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}