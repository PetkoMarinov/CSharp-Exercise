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

            string result = GetLatestProjects(context);

            Console.WriteLine(result);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastTen = context.Projects
                .OrderByDescending(p=>p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var item in lastTen)
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

