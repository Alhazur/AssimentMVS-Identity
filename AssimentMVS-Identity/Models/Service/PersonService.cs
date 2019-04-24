using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Interface;
using AssimentMVS_Identity.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssimentMVS_Identity.Models.Service
{
    public class PersonService : IPersonService
    {
        CountryVM Country = new CountryVM();

        private readonly TravelDbContext _travelDbContext;

        public PersonService(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public List<Person> AllPersons()
        {
            return _travelDbContext.People.Include(c => c.City).ToList();//?????????????
        }

        public Person CreatePersonWithoutCity(Person person)
        {
            if (person == null)
            {
                return null;
            }

            Person newPerson = new Person()
            {
                Name = person.Name,
                Age = person.Age,
            };

            if (newPerson != null)
            {
                _travelDbContext.People.Add(newPerson);
                _travelDbContext.SaveChanges();

                return newPerson;
            }

            return null;
        }

        public Person CreatePerson(Person person, int cityId)//koppla person till City
        {
            var city = _travelDbContext.Cities
                   .Include(c => c.People)//koppla person till City
                   .SingleOrDefault(c => c.Id == cityId);

            city.People.Add(person);//koppla person till City

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
            return _travelDbContext.People
                   .Include(c => c.City)//?????????????
                .SingleOrDefault(c => c.Id == id);
        }

        public Person FindPersonWithCity(int? id)
        {
            if (id != null)
            {
                return _travelDbContext.People
                    .Include(c => c.City)
                    .SingleOrDefault(c => c.Id == id);
            }
            return null;
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

        public bool UpdatePersonWithCity(Person person, int? id)
        {
            bool wasUpdate = false;

            Person stud = _travelDbContext.People
                .Include(c => c.City)
                .ThenInclude(c => c.Country)
                .SingleOrDefault(teachers => teachers.Id == person.Id);

            {
                if (stud != null)
                {
                    stud.Name = person.Name;
                    stud.Age = person.Age;
                    stud.City = person.City;//?????????????

                    _travelDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
