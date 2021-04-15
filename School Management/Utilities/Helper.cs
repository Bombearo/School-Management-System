using System.Configuration;

namespace School_Management.Utilities
{
    public static class Helper
    {
        public static string GetConnectionString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
           
        }

    }
}
