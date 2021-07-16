using System;
using BirthdayCelebrations.Classes;
using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations
{
    public class Citizen : Inhabitant, IIdentical, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name)
        {
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }

        public override string BirthYear()
        {
            return Birthdate.Substring(Birthdate.Length - 4, 4);
        }

        public override void Print(string property)
        {
            Console.WriteLine(property.ToLower() == "name" ? Name
                : property.ToLower() == "age" ? Age.ToString()
                : property.ToLower() == "id" ? Id
                : property.ToLower() == "birthdate" ? Birthdate : throw new Exception());
        }
    }
}

