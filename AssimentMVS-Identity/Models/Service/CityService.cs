using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AssimentMVS_Identity.Models.Service
{
    public class CityService : ICityService
    {
        private readonly TravelDbContext _travelDbContext;

        public CityService(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public List<City> AllCities()
        {
            return _travelDbContext.Cities.ToList();
        }

        public City CreateCity(City city, int countryId)//001
        {
            var name = _travelDbContext.Countries
                .Include(c => c.Cities)//001
                .ThenInclude(p => p.People)
                .SingleOrDefault(c => c.Id == countryId);

            name.Cities.Add(city);//001

            _travelDbContext.SaveChanges();
            return city;
        }

        public bool DeleteCity(int id)
        {
            bool wasRemoved = false;

            City city = _travelDbContext.Cities
                .Include(p => p.People)
                .SingleOrDefault(g => g.Id == id);

            if (city == null)
            {
                return wasRemoved;
            }

            _travelDbContext.Cities.Remove(city);
            _travelDbContext.SaveChanges();
            return wasRemoved;
        }

        public City FindCity(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var city = _travelDbContext.Cities
                .Include(p => p.People)
                .Include(c => c.Country)
                .SingleOrDefault(x => x.Id == id);

            return city;

            //return _travelDbContext.Cities.SingleOrDefault(c => c.Id == id);
        }

        public bool UpdateCity(City city)
        {
            bool wasUpdate = false;
            City orig = _travelDbContext.Cities
                .Include(p => p.People)
                .SingleOrDefault(s => s.Id == city.Id);
            {
                if (orig != null)
                {
                    orig.Name = city.Name;

                    _travelDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
