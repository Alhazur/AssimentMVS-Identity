using System.Collections.Generic;

namespace AssimentMVS_Identity.Models.Interface
{
    public interface IPersonService
    {
        Person CreatePerson(Person person, int cityId);

        List<Person> AllPersons();

        Person FindPerson(int id);

        bool UpdatePerson(Person person);

        bool UpdatePersonWithCity(Person person, int? id);

        bool DeletePerson(int id);

        //Person CreatePersonWithoutCity(Person person);

        Person FindPersonWithCity(int? id);
    }
}
