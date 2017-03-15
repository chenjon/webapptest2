using System;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void CreateDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        public static void InitializeDatabase(string connectionString)
        {
            var dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();

            try
            {
                var command =
                    new SQLiteCommand(
                        "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static SQLiteConnection GetConnection(string connectionString)
        {
            var dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp(string connectionString)
        {
            var dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();

            try
            {
                var command =
                    new SQLiteCommand(
                        "drop table PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}