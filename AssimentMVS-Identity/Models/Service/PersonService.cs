using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssimentMVS_Identity.Models.Service
{
    public class PersonService : IPersonService
    {
        private readonly TravelDbContext _travelDbContext;

        public PersonService(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public List<Person> AllPersons()
        {
            return _travelDbContext.People.ToList();
        }

        public Person CreatePerson(string name, int age)
        {
            Person person = new Person() { Name = name, Age = age };

            _travelDbContext.People.Add(person);
            _travelDbContext.SaveChanges();
            return person;
        }

        public bool DeletePerson(int id)
        {
            bool wasRemoved = false;

            Person person = _travelDbContext.People.SingleOrDefault(g => g.Id == id);

            if (person == null)
            {
                return wasRemoved;
            }

            _travelDbContext.People.Remove(person);
            _travelDbContext.SaveChanges();
            return wasRemoved;
        }

        public Person FindPerson(int id)
        {
            return _travelDbContext.People.SingleOrDefault(c => c.Id == id);
        }

        public bool UpdatePerson(Person person)
        {
            bool wasUpdate = false;
            Person stud = _travelDbContext.People
                .SingleOrDefault(teachers => teachers.Id == person.Id);
            {
                if (stud != null)
                {
                    stud.Name = person.Name;
                    stud.Age = person.Age;

                    _travelDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
