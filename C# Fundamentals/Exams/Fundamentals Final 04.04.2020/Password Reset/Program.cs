using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder pass = new StringBuilder(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] instruction = input.Split();
                string command = instruction[0];

                switch (command)
                {
                    case "TakeOdd":
                        StringBuilder temp = new StringBuilder();
                        for (int i = 1; i < pass.Length; i += 2)
                        {
                            temp.Append(pass[i]);
                        }
                        pass = temp;
                        Console.WriteLine(pass); break;

                    case "Cut":
                        int index = int.Parse(instruction[1]);
                        int length = int.Parse(instruction[2]);
                        pass.Remove(index, length);
                        Console.WriteLine(pass); break;

                    case "Substitute":
                        string substring = instruction[1];
                        string substitute = instruction[2];

                        if (pass.ToString().Contains(substring))
                        {
                            pass.Replace(substring, substitute);
                            Console.WriteLine(pass);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {pass.ToString()}");
        }
    }
}
