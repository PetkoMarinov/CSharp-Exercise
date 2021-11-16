namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            string result = GetGoldenBooks(db);
            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == Enum.Parse<EditionType>("gold", true))
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            StringBuilder sb = new StringBuilder();

            foreach (string title in goldenBooks)
            {
                sb.AppendLine($"{title}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
