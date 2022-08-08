using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Data_Layer
{
    public class DB_Connect
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public SqlConnection OpensqlConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public SqlConnection ClosedsqlConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }

    }
}
