using System;
using System.Data;
using System.Data.SqlClient;

namespace Conexion
{
    public class Conexion
    {
        public static string ConnectionString()
        {
            string connectionString = "Data Source=LAPTOP-7L7Q5LQQ;Initial Catalog=ExamenBrive;Integrated Security=True";
            return connectionString;
        }
        public static SqlCommand CreateCommand(string Query, SqlConnection context)
        {
            context.Open();
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
