using System.Collections.Generic;
using People.Dal.Entities;

namespace People.Dal.Abstract
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> Get();

        Person GetById(int id);

        void Add(Person person);

        void Update(Person person);

        void Delete(int id);
    }
}