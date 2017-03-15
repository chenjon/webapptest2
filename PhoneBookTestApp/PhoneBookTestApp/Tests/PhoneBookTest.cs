using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace PhoneBookTestApp.Tests
{
    [TestFixture]
    public class PhoneBookTest
    {
        private Mock<IPhoneBookDataProvider> _phoneBookDataProvider;

        [OneTimeSetUp]
        public void Init()
        {
            _phoneBookDataProvider = new Mock<IPhoneBookDataProvider>();
        }

        [Test]
        public void FindPerson_Found()
        {
            //arrange
            var firstName = "John";
            var lastName = "Doe";
            _phoneBookDataProvider.Setup(m => m.FindPerson(firstName, lastName)).Returns(
                new Person
                {
                    Name = "John Doe",
                    PhoneNumber = "248-123-1234",
                    Address = "12345 Test Dr., Northvill, MI 48167"
                }
            );
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var personObject = phoneBook.FindPerson(firstName, lastName);

            //assert
            Assert.IsTrue(personObject.Name == $"{firstName} {lastName}");
        }
        [Test]
        public void FindPerson_NotFound()
        {
            //arrange
            var firstName = "John";
            var lastName = "Doe";
            Person returnPerson = null;
            _phoneBookDataProvider.Setup(m => m.FindPerson(firstName, lastName)).Returns(returnPerson);
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var personObject = phoneBook.FindPerson(firstName, lastName);

            //assert
            Assert.IsTrue(returnPerson == null);
        }


        [Test]
        public void AddPerson_Success()
        {
            //arrange
            Person person = new Person
            {
                Name = "New Smith",
                PhoneNumber = "(248) 555-1234",
                Address = "1234 Test Dr, Royal Oak, MI"
            };
            _phoneBookDataProvider.Setup(m => m.AddPerson(person)).Returns(true);
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var result = phoneBook.AddPerson(person);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddPerson_Fail()
        {
            //arrange
            Person person = new Person
            {
                Name = "New Smith",
                PhoneNumber = "(248) 555-1234",
                Address = "1234 Test Dr, Royal Oak, MI"
            };
            _phoneBookDataProvider.Setup(m => m.AddPerson(person)).Returns(false);
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var result = phoneBook.AddPerson(person);

            //assert
            Assert.IsTrue(!result);
        }

        [Test]
        public void GetAll_Found()
        {
            //arrange
            var all = new List<Person>
            {
                new Person
                {
                    Name = "John Doe",
                    PhoneNumber = "248-123-1234",
                    Address = "1234 Test Dr, Royal Oak, MI"
                }
            };
            _phoneBookDataProvider.Setup(m => m.GetAll()).Returns(all);
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var people = phoneBook.GetAll();

            //assert
            Assert.IsTrue(people.Count > 0);
        }
        [Test]
        public void GetAll_NotFound()
        {
            //arrange
            var all = new List<Person>();
            _phoneBookDataProvider.Setup(m => m.GetAll()).Returns(all);
            var phoneBook = new PhoneBook(_phoneBookDataProvider.Object);

            //act
            var people = phoneBook.GetAll();

            //assert
            Assert.IsTrue(people.Count == 0);
        }

    }
}