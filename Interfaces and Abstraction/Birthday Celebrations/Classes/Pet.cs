namespace BirthdayCelebrations
{
    using System;
    using BirthdayCelebrations.Classes;
    using BirthdayCelebrations.Interfaces;

    public class Pet : Inhabitant, IBirthable
    {
        public Pet(string name, string birthdate) : base(name)
        {
            this.Birthdate = birthdate;
        }

        public string Birthdate { get;}

        public override string BirthYear()
        {
            return Birthdate.Substring(Birthdate.Length - 4, 4);
        }

        public override void Print(string property)
        {
            Console.WriteLine(property.ToLower() == "name" ? Name
                : property.ToLower() == "birthdate" ? Birthdate : throw new Exception());
        }
    }
}
