using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                 .Towns
                 .FirstOrDefault(x => x.Name == "Seattle");

            var addresses = context
                .Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town == town)
                .ToList();

            foreach (var address in addresses)
            {
                foreach (var employee in address.Employees)
                {
                    employee.AddressId = null;
                }

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}

