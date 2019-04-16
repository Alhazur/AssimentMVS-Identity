using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Interface;
using Microsoft.EntityFrameworkCore;
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

        public Person CreatePerson(Person person, int perId)//001
        {
            var name = _travelDbContext.Cities
                   .Include(c => c.People)//001
                   .SingleOrDefault(c => c.Id == perId);

            name.People.Add(person);//001

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
