using SoftUni.Data;
using SoftUni.Models;
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

            string result = AddNewAddressToEmployee(context);

            Console.WriteLine(result);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            address.Employees.Add(employee);
            context.SaveChanges();

            var data = context.Employees
                .Select(e => new { e.Address.AddressText, e.AddressId })
                .OrderByDescending(e => e.AddressId)
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var record in data)
            {
                sb.AppendLine(record.AddressText);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
