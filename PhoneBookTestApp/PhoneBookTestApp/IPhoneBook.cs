using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person FindPerson(string firstName, string lastName);
        bool AddPerson(Person newPerson);
        IList<Person> GetAll();
    }
}