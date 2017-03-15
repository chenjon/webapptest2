using System;

namespace PhoneBookTestApp
{
    internal class Program
    {
        private static PhoneBook _phonebook;

        private static void Main(string[] args)
        {
            var dataProvider = new PhoneBookDataProvider();
            _phonebook = new PhoneBook(dataProvider);
            dataProvider.CreateDatabase();

            try
            {
                dataProvider.InitializeDatabase();

                CreatePersonAddedDatabase();

                FindAndPrintPerson();

                AddPersonToDatabase();

                Console.ReadKey();
            }
            finally
            {
                dataProvider.CleanUp();
            }
        }

        private static void CreatePersonAddedDatabase()
        {
            /* TODO: create person objects and put them in the PhoneBook and database
            * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
            * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
            */
            var person = new Person
            {
                Name = "John Smith",
                PhoneNumber = "(248) 123-4567",
                Address = "1234 Sand Hill Dr, Royal Oak, MI"
            };
            _phonebook.AddPerson(person);

            person.Name = "Cynthia Smith";
            person.PhoneNumber = "(824) 128-8758";
            person.Address = "875 Main St, Ann Arbor, MI";
            _phonebook.AddPerson(person);

            // TODO: print the phone book out to System.out
            var all = _phonebook.GetAll();
            Console.WriteLine("======TODO: print the phone book out to System.out======");
            foreach (var p in all)
                PrintPerson(p);
        }

        private static void FindAndPrintPerson()
        {
            // TODO: find Cynthia Smith and print out just her entry
            var personFound = _phonebook.FindPerson("Cynthia", "Smith");

            Console.WriteLine("\n======TODO: find Cynthia Smith and print out just her entry======");
            PrintPerson(personFound);
        }

        private static void AddPersonToDatabase()
        {
            // TODO: insert the new person objects into the database
            var newPerson = new Person
            {
                Name = "New Smith",
                PhoneNumber = "(248) 555-1234",
                Address = "1234 Test Dr, Royal Oak, MI"
            };
            _phonebook.AddPerson(newPerson);
        }


        private static void PrintPerson(Person person)
        {
            if (person != null)
                Console.WriteLine($"Name: {person.Name}, Phone: {person.PhoneNumber}, Address: {person.Address}");
        }
    }
}