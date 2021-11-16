namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            string input = Console.ReadLine();
            string result = GetAuthorNamesEndingIn(db, input);
            Console.WriteLine(result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a);

            StringBuilder sb = new StringBuilder();

            foreach (var name in authorsNames)
            {
                sb.AppendLine($"{name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
