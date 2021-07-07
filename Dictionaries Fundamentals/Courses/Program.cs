using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses =
                new Dictionary<string, List<string>>();

            while (input != "end")
            {
                string course = input.Split(" : ")[0];
                string student = input.Split(" : ")[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string> { student });
                }
                else
                {
                    courses[course].Add(student);
                }

                input = Console.ReadLine();
            }

            courses = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var name in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }

        }
    }
}
