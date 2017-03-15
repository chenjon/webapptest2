using System.Configuration;

namespace PhoneBookTestApp.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings["ConnectionString"];
            var connStirng = "Data Source = MyDatabase.sqlite; Version = 3;";
            if (conn != null)
                connStirng = conn.ConnectionString;

            return connStirng;
        }
    }
}