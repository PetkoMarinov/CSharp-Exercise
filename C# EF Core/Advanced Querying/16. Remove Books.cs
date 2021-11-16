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

            Console.WriteLine(RemoveBooks(db)); 
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var count = context.Books
                .Where(b => b.Copies < 4200).Count();
            var deleted = context.Books
                .Where(b => b.Copies < 4200);

            context.RemoveRange(deleted);
            context.SaveChanges();
            return count;
        }
    }
}
