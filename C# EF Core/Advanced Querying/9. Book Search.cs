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
            //Initializer.DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b);

            StringBuilder sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine($"{title}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
