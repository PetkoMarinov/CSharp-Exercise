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
            //Initializer.DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            string result = GetBooksNotReleasedIn(db, 2000);
            Console.WriteLine(result);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
               .Where(b => b.ReleaseDate.Value.Year != year)
               .OrderBy(b => b.BookId)
               .Select(b => b.Title);

            StringBuilder sb = new StringBuilder();

            foreach (string title in books)
            {
                sb.AppendLine($"{title}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
