using System.Configuration;
using System.Data.SqlClient;

namespace StoreService
{
    class WebConfigSettings
    {
        public static string ConnectionStringName = "EmpConnString";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
        }
    }
}
