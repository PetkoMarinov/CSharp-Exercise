namespace ValidationAttributes
{
    public class Person
    {
        private const int MIN = 12;
        private const int MAX = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; set; }
        
        [MyRangeAttribute(MIN, MAX)]
        public int Age { get; set; }
    }
}
