using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoreService
{
    class MySqlProcedure
    {
        private SqlConnection _connection;

        public MySqlProcedure()
        {
            _connection = WebConfigSettings.GetConnection();
            _connection.Open();
        }

        ~MySqlProcedure()
        {
            _connection.Close();
        }

        public SqlDataReader Reader(string ProcedureName, Dictionary<string, object> ProcedureArgs)
        {
            SqlCommand cmd = new SqlCommand(ProcedureName, _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ProcedureArgs != null) 
                foreach(var item in ProcedureArgs)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, (item.Value != null) ? item.Value : DBNull.Value));
                }
            return cmd.ExecuteReader();
        }

        public int NoQuery(string ProcedureName, Dictionary<string, object> ProcedureArgs)
        {
            SqlCommand cmd = new SqlCommand(ProcedureName, _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ProcedureArgs != null)
                foreach (var item in ProcedureArgs)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, (item.Value != null) ? item.Value : DBNull.Value));
                }
            return cmd.ExecuteNonQuery();
        }
    }
}
