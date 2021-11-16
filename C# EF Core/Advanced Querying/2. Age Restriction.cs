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

            string command = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, command);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
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
