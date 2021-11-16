namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
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

            string result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitPerCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(b => b.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in profitPerCategory)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
