using AssimentMVS_Identity.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.Interface
{
    interface ICityService
    {
        City CreateCity(string name);

        List<City> AllCities();

        City FindCity(int id);

        bool DeleteCity(int id);

        bool UpdateCity(City city);
    }
}
