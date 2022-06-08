using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people = new List<Person>();

        //Methods
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            foreach (Person person in people)
                if (person.Age > maxAge)
                    maxAge = person.Age;
            int index = people.FindIndex(person => person.Age == maxAge);
            return people[index];
        }
    }
}
