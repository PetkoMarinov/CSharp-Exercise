using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> listOfExecutedCommands = new Stack<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                switch (command)
                {
                    case "1":
                        listOfExecutedCommands.Push(text.ToString());
                        string addedText = input[1];
                        text.Append(addedText);
                        break;

                    case "2":
                        listOfExecutedCommands.Push(text.ToString());
                        int eraseCount = int.Parse(input[1]);
                        text = text.Remove(text.Length - eraseCount, eraseCount);
                        break;

                    case "3":
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;

                    case "4":
                        text = new StringBuilder(listOfExecutedCommands.Pop());
                        break;
                }
            }
        }
    }
}