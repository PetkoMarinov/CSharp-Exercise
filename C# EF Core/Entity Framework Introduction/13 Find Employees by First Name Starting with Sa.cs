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
            context.EmployeesProjects.Where(p=>p.ProjectId)

            StringBuilder sb = new StringBuilder();


            return sb.ToString().TrimEnd();
        }
    }
}

