using System.Collections.Generic;

namespace AssimentMVS_Identity.Models.Interface
{
    public interface IPersonService
    {
        Person CreatePerson(string name, int age);

        List<Person> AllPersons();

        Person FindPerson(int id);

        bool DeletePerson(int id);

        bool UpdatePerson(Person person);
    }
}
