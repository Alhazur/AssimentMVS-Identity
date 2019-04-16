using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.Class;
using AssimentMVS_Identity.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public City CreateCity(string name)
        {
            City city = new City() { Name = name };

            _travelDbContext.Cities.Add(city);
            _travelDbContext.SaveChanges();
            return city;
        }

        public bool DeleteCity(int id)
        {
            bool wasRemoved = false;

            City city = _travelDbContext.Cities.SingleOrDefault(g => g.Id == id);

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
            return _travelDbContext.Cities.SingleOrDefault(c => c.Id == id);
        }

        public bool UpdateCity(City city)
        {
            bool wasUpdate = false;
            City orig = _travelDbContext.Cities
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
