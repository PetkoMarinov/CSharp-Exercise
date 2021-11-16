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

            string result = GetEmployeesFullInformation(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var data = context.Employees
             .Select(x => new { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary, x.EmployeeId })
             .OrderBy(x => x.EmployeeId);

            StringBuilder sb = new StringBuilder();

            foreach (var record in data)
            {
                sb.AppendLine(
                    $"{record.FirstName} {record.LastName} {record.MiddleName} " +
                    $"{record.JobTitle} {record.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
