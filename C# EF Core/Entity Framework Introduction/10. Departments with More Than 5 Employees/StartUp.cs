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

            string result = GetDepartmentsWithMoreThan5Employees(context);

            Console.WriteLine(result);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .Select(x => new { x.Name, x.Manager, x.Employees })
                    .OrderBy(x => x.Employees.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.Manager.FirstName} " +
                    $"{department.Manager.LastName}");

                foreach (var employee in department.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

