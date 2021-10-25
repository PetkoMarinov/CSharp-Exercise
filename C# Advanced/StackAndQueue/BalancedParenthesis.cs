using System;
using System.Collections.Generic;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            int length = input.Length;
            bool simetric = false;

            for (int i = 0; i < length; i++)
            {
                switch (input[i])
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(input[i]); break;

                    case ')':

                        if (stack.Count!=0 && stack.Peek() == '(')
                        {
                            simetric = true;
                            stack.Pop();
                        }
                        else
                        {
                            simetric = false;
                            Console.WriteLine("NO"); return;
                        }
                        break;


                    case ']':

                        if (stack.Count != 0 && stack.Peek() == '[')
                        {
                            simetric = true;
                            stack.Pop();
                        }
                        else
                        {
                            simetric = false;
                            Console.WriteLine("NO"); return;
                        }
                        break;

                    case '}':

                        if (stack.Count != 0 && stack.Peek() == '{')
                        {
                            simetric = true;
                            stack.Pop();
                        }
                        else
                        {
                            simetric = false;
                            Console.WriteLine("NO"); return;
                        }
                        break;
                }
            }

            if (simetric)
            {
                Console.WriteLine("YES");
            }

        }
    }
}