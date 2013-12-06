using System.Data.SqlClient;

namespace StoreService
{
    class WebConfigSettings
    {
        public static string ConnectionStringName = "EmpConnString";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
        }
    }
}
