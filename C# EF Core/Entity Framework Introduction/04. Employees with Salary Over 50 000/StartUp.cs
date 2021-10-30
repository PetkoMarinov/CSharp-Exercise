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

            string result = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var data = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            StringBuilder sb = new StringBuilder();

            foreach (var record in data)
            {
                sb.AppendLine($"{ record.FirstName} - {record.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
