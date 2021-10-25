using System;
using System.Text;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input);

            while (input != "Reveal")
            {
                string[] data = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "InsertSpace":
                        int insertIndex = int.Parse(data[1]);
                        sb.Insert(insertIndex, " ");
                        Console.WriteLine(sb.ToString()); break;

                    case "Reverse":
                        string forReverse = data[1];
                        if (sb.ToString().Contains(forReverse))
                        {
                            int index = sb.ToString().IndexOf(forReverse);

                            StringBuilder reversed = new StringBuilder();

                            for (int i = forReverse.Length - 1; i >= 0; i--)
                            {
                                reversed.Append(forReverse[i]);
                            }

                            sb.Remove(index, reversed.Length);
                            sb.Append(reversed);
                            Console.WriteLine(sb.ToString());
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "ChangeAll":
                        string toReplace = data[1];
                        string substitute = data[2];
                        sb.Replace(toReplace, substitute);
                        Console.WriteLine(sb.ToString()); break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {sb.ToString()}");
        }
    }
}
