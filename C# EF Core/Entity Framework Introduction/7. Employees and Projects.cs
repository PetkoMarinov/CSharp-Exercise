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

            string result = GetEmployeesInPeriod(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var data = context.Employees
                .Where(e => e.EmployeesProjects.Any
                    (p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects.Select(p => p.Project)
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var record in data)
            {
                sb.AppendLine($"{record.FirstName} {record.LastName} - " +
                    $"Manager: {record.ManagerFirstName} {record.ManagerLastName}");

                foreach (var project in record.Project)
                {
                    string projectName = project.Name;
                    string projectStartDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                    string projectEndDate = project.EndDate is null?
                        "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt");

                    sb.AppendLine($"--{projectName} - {projectStartDate} - {projectEndDate}");
                }

            }

            return sb.ToString().TrimEnd();
        }
    }
}
