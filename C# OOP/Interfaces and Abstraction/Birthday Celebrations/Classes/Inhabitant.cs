using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Classes
{
    public abstract class Inhabitant : INameable
    {
        public string Name { get; }

        public Inhabitant(string name)
        {
            this.Name = name;
        }

        public abstract void Print(string property);

        public abstract string BirthYear();
    }
}
