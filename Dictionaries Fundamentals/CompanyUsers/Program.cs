using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string company = input.Split(" -> ")[0];
                string Id = input.Split(" -> ")[1];

                if (!companyUsers.ContainsKey(company))
                {
                    companyUsers.Add(company, new List<string> { Id });
                }
                else if (!companyUsers[company].Contains(Id))
                {
                    companyUsers[company].Add(Id);
                }

                input = Console.ReadLine();
            }

            companyUsers = companyUsers
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var employee in companyUsers)
            {
                Console.WriteLine(employee.Key);

                foreach (var value in employee.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}