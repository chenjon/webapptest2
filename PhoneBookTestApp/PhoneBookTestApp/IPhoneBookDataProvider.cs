using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBookDataProvider
    {
        Person FindPerson(string firstName, string lastName);
        bool AddPerson(Person newPerson);
        IList<Person> GetAll();

        void InitializeDatabase();
        void CleanUp();

        void CreateDatabase();
    }
}