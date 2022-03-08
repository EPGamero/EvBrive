using System;
using System.Data;
using System.Data.SqlClient;

namespace Conexion
{
    public class Conexion
    {
        public static string ConnectionString()
        {
            string connectionString = "";
            return connectionString;
        }
        public static SqlCommand CreateCommand(string Query, SqlConnection context)
        {
            SqlCommand cmd = new SqlCommand(Query, context);
            return cmd;
        }
        public static int ExecuteCommand(SqlCommand cmd)
        {
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public static DataTable ExecuteCommandSelect(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
    }
}
