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

            string result = GetEmployeesFromResearchAndDevelopment(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var data = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary, })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            StringBuilder sb = new StringBuilder();

            foreach (var record in data)
            {
                sb.AppendLine($"{record.FirstName} {record.LastName} from Research and Development - " +
                    $"${record.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
