using System.Collections.Generic;
using People.Dal.Abstract;
using People.Dal.Entities;

namespace People.Dal.Concrete
{
    public class PeopleRepository : IPeopleRepository
    {
        private static List<Person> _people = new List<Person>
        {
            new Person { Id = 1, FirstName = "Andrew", LastName = "Kur", Age = 33 },
            new Person { Id = 2, FirstName = "Alex", LastName = "Test", Age = 23 },
            new Person { Id = 3, FirstName = "Anna", LastName = "LastName", Age = 20 },
            new Person { Id = 4, FirstName = "Olga", LastName = "Kos", Age = 34 }
        };

        public void Add(Person person) => _people.Add(person);

        public void Delete(int id) => _people.RemoveAll(p => p.Id == id);

        public IEnumerable<Person> Get() => _people;

        public Person GetById(int id) => _people.Find(m => m.Id == id);

        public void Update(Person person)
        {
            Person p = GetById(person.Id);
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Age = person.Age;
        }
    }
}