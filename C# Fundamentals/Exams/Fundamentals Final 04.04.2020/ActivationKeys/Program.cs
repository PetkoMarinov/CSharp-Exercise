using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivationKey activationKey = new ActivationKey(Console.ReadLine());
            string instructions = Console.ReadLine();

            while (instructions != "Generate")
            {
                string[] instructionsData = instructions.Split(">>>");
                string command = instructionsData[0];

                switch (command)
                {
                    case "Contains":
                        string substring = instructionsData[1];
                        activationKey.Contains(substring); break;

                    case "Flip":
                        string upLowCommand = instructionsData[1];
                        int flipStartIndex = int.Parse(instructionsData[2]);
                        int flipEndIndex = int.Parse(instructionsData[3]);
                        activationKey.Flip(upLowCommand, flipStartIndex, flipEndIndex);
                        Print(activationKey.Text); break;

                    case "Slice":
                        int sliceStartIndex = int.Parse(instructionsData[1]);
                        int sliceEndIndex = int.Parse(instructionsData[2]);
                        activationKey.Slice(sliceStartIndex, sliceEndIndex);
                        Print(activationKey.Text); break;
                }

                instructions = Console.ReadLine();
            }

            Print($"Your activation key is: {activationKey.Text}");
        }
        public static void Print(string text) => Console.WriteLine(text);
    }

    public class ActivationKey
    {
        public ActivationKey(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        public void Contains(string substring)
        {
            if (this.Text.Contains(substring))
            {
                Console.WriteLine($"{this.Text} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        public string Flip(string command, int startIndex, int endIndex)
        {
            string flip = command == "Upper"
                    ? this.Text.Substring(startIndex, endIndex - startIndex).ToUpper()
                    : this.Text.Substring(startIndex, endIndex - startIndex).ToLower();

            this.Text = this.Text.Remove(startIndex, endIndex - startIndex);
            this.Text = this.Text.Insert(startIndex, flip);
            return this.Text;
        }

        public string Slice(int startIndex, int endIndex)
        {
            this.Text = this.Text.Remove(startIndex, endIndex - startIndex);
            return this.Text;
        }
    }
}
