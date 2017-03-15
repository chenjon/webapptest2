using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PhoneBookTestApp.Helpers;

namespace PhoneBookTestApp
{
    public class PhoneBookDataProvider : IPhoneBookDataProvider
    {
        public Person FindPerson(string firstName, string lastName)
        {
            var dbConnection = DatabaseUtil.GetConnection(ConfigurationHelper.GetConnectionString());
            var command =
                new SQLiteCommand(
                    $"SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK WHERE NAME = '{firstName} {lastName}'",
                    dbConnection);
            var sqlReader = command.ExecuteReader();

            try
            {
                while (sqlReader.Read())
                {
                    var person = new Person
                    {
                        Name = sqlReader.GetString(0),
                        PhoneNumber = sqlReader.GetString(1),
                        Address = sqlReader.GetString(2)
                    };

                    return person;
                }
            }
            finally
            {
                sqlReader.Close();
                dbConnection.Close();
            }

            return null;
        }

        public bool AddPerson(Person newPerson)
        {
            var dbConnection = DatabaseUtil.GetConnection(ConfigurationHelper.GetConnectionString());
            try
            {   
                var command =
                    new SQLiteCommand(
                        $"INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('{newPerson.Name}', '{newPerson.PhoneNumber}', '{newPerson.Address}')",
                        dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
            finally
            {
                dbConnection.Close();
            }
        }

        public IList<Person> GetAll()
        {
            var all = new List<Person>();
            var dbConnection = DatabaseUtil.GetConnection(ConfigurationHelper.GetConnectionString());
            var command =
                new SQLiteCommand(
                    $"SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK",
                    dbConnection);
            var sqlReader = command.ExecuteReader();

            try
            {
                while (sqlReader.Read())
                {
                    var person = new Person
                    {
                        Name = sqlReader.GetString(0),
                        PhoneNumber = sqlReader.GetString(1),
                        Address = sqlReader.GetString(2)
                    };

                    all.Add(person);
                }
            }
            finally
            {
                sqlReader.Close();
                dbConnection.Close();
            }

            return all;
        }

        public void InitializeDatabase()
        {
            DatabaseUtil.InitializeDatabase(ConfigurationHelper.GetConnectionString());
        }

        public void CleanUp()
        {
            DatabaseUtil.CleanUp(ConfigurationHelper.GetConnectionString());
        }

        public void CreateDatabase()
        {
            DatabaseUtil.CreateDatabase();
        }
    }
}