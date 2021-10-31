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

            string result = IncreaseSalaries(context);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees.Where(e =>
            e.Department.Name == "Engineering" ||
            e.Department.Name == "Tool Design" ||
            e.Department.Name == "Marketing" ||
            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

