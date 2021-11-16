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

            string input = Console.ReadLine();
            string result = GetBooksByCategory(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var books = context.BooksCategories
                .Where(b => categories.Any(c=>c==b.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .OrderBy(b => b);

            StringBuilder sb = new StringBuilder();

            foreach (string title in books)
            {
                sb.AppendLine($"{title}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
