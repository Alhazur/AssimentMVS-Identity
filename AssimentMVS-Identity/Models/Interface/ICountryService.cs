using System.Collections.Generic;

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
