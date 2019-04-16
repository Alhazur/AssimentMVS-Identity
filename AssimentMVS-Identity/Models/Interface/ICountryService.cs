using AssimentMVS_Identity.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.Interface
{
    public interface ICountryService
    {
        Country CreateCountry(string name);

        List<Country> AllCountry();

        Country FindCountry(int id);

        bool UpdateCountry(Country country);

        bool DeleteCountry(int id);
    }
}
