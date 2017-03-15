using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private readonly IPhoneBookDataProvider _phoneBookDataProvider;

        public PhoneBook(IPhoneBookDataProvider phoneBookDataProvider)
        {
            _phoneBookDataProvider = phoneBookDataProvider;
        }

        public Person FindPerson(string firstName, string lastName)
        {
            return _phoneBookDataProvider.FindPerson(firstName, lastName);
        }

        public bool AddPerson(Person newPerson)
        {
            return _phoneBookDataProvider.AddPerson(newPerson);
        }

        public IList<Person> GetAll()
        {
            return _phoneBookDataProvider.GetAll();
        }
    }
}