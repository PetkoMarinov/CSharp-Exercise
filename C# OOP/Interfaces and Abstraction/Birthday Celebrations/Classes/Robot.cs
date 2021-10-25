using BirthdayCelebrations.Classes;
using System;

namespace BirthdayCelebrations
{
    public class Robot : Inhabitant
    {
        public Robot(string name, string id) : base(name)
        {
            this.Id = id;
        }

        public string Id { get; }

        public override string BirthYear()
        {
            return null;
        }

        public override void Print(string property)
        {
            Console.WriteLine(property.ToLower() == "name" ? Name
                : property.ToLower() == "id" ? Id : throw new Exception());
        }
    }
}
