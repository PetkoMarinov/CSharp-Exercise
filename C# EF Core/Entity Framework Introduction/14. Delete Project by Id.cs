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

            string result = DeleteProjectById(context);

            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeProjects = context.EmployeesProjects.Where(е => е.ProjectId == 2).ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            var projectToRemove = context.Projects.Find(2);

            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

