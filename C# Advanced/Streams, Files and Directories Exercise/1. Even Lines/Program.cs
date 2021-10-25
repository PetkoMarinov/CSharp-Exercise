using System;
using System.IO;
using System.Text;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"C:\Users\сем. Маринови\Desktop\ДДС\CSharp\text.txt");

            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter("result.txt"))
                {
                    while (line != null)
                    {
                        char[] symbols = { '.', ',', '-', '!', '?' };
                        line = ReplaceSymbols(symbols, line);
                        line = ReverseText(line);

                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static string ReverseText(string line)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length / 2; i++)
            {
                string temp = words[words.Length - 1 - i];
                words[words.Length - 1 - i] = words[i];
                words[i] = temp;
            }

            return string.Join(' ', words);
        }

        static string ReplaceSymbols(char[] arr, string text)
        {
            StringBuilder sb = new StringBuilder(text);
            for (int i = 0; i < sb.Length; i++)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    if (sb[i] == arr[k])
                    {
                        sb[i] = '@';
                    }
                }
            }
            return sb.ToString();
        }
    }
}
