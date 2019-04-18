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
            return _travelDbContext.People.ToList();
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

        public Person CreatePerson(Person person, int cityId)//001
        {
            var city = _travelDbContext.Cities
                   .Include(c => c.People)//001
                   .SingleOrDefault(c => c.Id == cityId);

            city.People.Add(person);//001

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

        public Person FindPersonWithCity(int? id)
        {
            if (id != null || id != 0)
            {
                return _travelDbContext.People
                    .Include(x => x.City)
                    .SingleOrDefault(x => x.Id == id);
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

            //var city = _travelDbContext.Cities
            //    .Include(x=>x.People)
            //    .Include(x=>x.Country)
            //    .SingleOrDefault(x => x.Id == id);

            Person stud = _travelDbContext.People
                .Include(x => x.City)
                .ThenInclude(x=>x.Country)
                .SingleOrDefault(teachers => teachers.Id == person.Id);

            {
                if (stud != null)
                {
                    stud.Name = person.Name;
                    stud.Age = person.Age;
                    //stud.City = city;

                    _travelDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
