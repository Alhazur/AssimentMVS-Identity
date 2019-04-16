using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Class;
using AssimentMVS_Identity.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly TravelDbContext _travelDbContext;

        public CountryService(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public List<Country> AllCountry()
        {
            return _travelDbContext.Countries.ToList();
        }

        public Country CreateCountry(string name)
        {
            Country country = new Country() { Name = name };

            _travelDbContext.Countries.Add(country);
            _travelDbContext.SaveChanges();
            return country;
        }

        public bool DeleteCountry(int id)
        {
            bool wasRemoved = false;

            Country country = _travelDbContext.Countries.SingleOrDefault(g => g.Id == id);

            if (country == null)
            {
                return wasRemoved;
            }

            _travelDbContext.Countries.Remove(country);
            _travelDbContext.SaveChanges();
            return wasRemoved;
        }

        public Country FindCountry(int id)
        {
            return _travelDbContext.Countries.SingleOrDefault(c => c.Id == id);
        }

        public bool UpdateCountry(Country country)
        {
            bool wasUpdate = false;
            Country stud = _travelDbContext.Countries
                .SingleOrDefault(teachers => teachers.Id == country.Id);
            {
                if (stud != null)
                {
                    stud.Name = country.Name;

                    _travelDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
