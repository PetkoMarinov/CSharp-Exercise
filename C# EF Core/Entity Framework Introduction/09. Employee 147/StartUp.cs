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

            string result = GetEmployee147(context);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Find(147);
            StringBuilder sb = new StringBuilder();

            if (employee != null)
            {
                var projects = context.EmployeesProjects
                               .Where(e => e.EmployeeId == 147)
                               .Select(p => new { p.Project.Name })
                               .OrderBy(p => p.Name);

                var employeeInfo = context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    }).ToList();

                string firstName = employeeInfo[0].FirstName;
                string lastName = employeeInfo[0].LastName;
                string jobTitle = employeeInfo[0].JobTitle;

                sb.AppendLine($"{firstName} {lastName} - {jobTitle}");

                foreach (var project in projects)
                {
                    sb.AppendLine($"{project.Name}");
                }
            }
           
            return sb.ToString().TrimEnd();
        }
    }
}
