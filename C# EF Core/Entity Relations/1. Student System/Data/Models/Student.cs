using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            var CourseEnrollment = new HashSet<StudentCourse>();
            var HomeworkSubmissions = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        //•	Student:
        //        o StudentId
        //o Name - (up to 100 characters, unicode)
        //o PhoneNumber - (exactly 10 characters, not unicode, not required)
        //o RegisteredOn
        //o Birthday - (not required)

    }
}
