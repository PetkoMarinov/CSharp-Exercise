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

            string result = CountCopiesByAuthor(db);
            Console.WriteLine(result);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(a => new
                {
                    Copies = a.Books.Sum(b => b.Copies),
                    Author = a.FirstName + " " + a.LastName
                })
                .OrderByDescending(b => b.Copies);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Author} - {book.Copies}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
