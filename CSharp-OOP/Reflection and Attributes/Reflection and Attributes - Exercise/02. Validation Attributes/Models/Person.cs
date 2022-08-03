namespace ValidationAttributes.Models
{
    using Utilities.Attributes;
    public class Person
    {
        private const int MinValueAge = 12;
        private const int MaxValueAge = 90;

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MinValueAge, MaxValueAge)]
        public int Age { get; set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
