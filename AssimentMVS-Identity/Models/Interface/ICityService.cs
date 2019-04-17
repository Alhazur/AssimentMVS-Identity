using System.Collections.Generic;

namespace AssimentMVS_Identity.Models.Interface
{
    public interface ICityService
    {
        City CreateCity(City city, int countryId);//001

        List<City> AllCities();

        City FindCity(int id);

        bool UpdateCity(City city);

        bool DeleteCity(int id);
    }
}
