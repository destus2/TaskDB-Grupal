using System.Configuration;
using System.Data.SqlClient;

namespace TaskDB
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string cadena = ConfigurationManager
                .ConnectionStrings["TaskDBConnection"]
                .ConnectionString;

            return new SqlConnection(cadena);
        }
    }
}