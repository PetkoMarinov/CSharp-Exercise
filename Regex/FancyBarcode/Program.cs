using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                Regex regexBarcode = new Regex(@"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+");
                Regex regexGroup = new Regex(@"\d");

                if (regexBarcode.IsMatch(input))
                {
                    StringBuilder group = new StringBuilder();

                    if (regexGroup.IsMatch(input))
                    {
                        MatchCollection matches = regexGroup.Matches(input);
                        
                        foreach (Match item in matches)
                        {
                            group.Append(item);
                        }
                    }
                    else
                    {
                        group.Append("00");
                    }
                    
                    Console.WriteLine($"Product group: {group}");
                    group.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
