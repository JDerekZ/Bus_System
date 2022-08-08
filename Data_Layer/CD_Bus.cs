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
    public class CD_Bus
    {
        private DB_Connect connect = new DB_Connect();

        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //for List
        public DataTable viewAll()
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Listar_Buses";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }


        //For Add or Create
        public void Create_Bus(string brand, string model, string plate, string color, string year)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Crear_Bus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@marca", brand);
            cmd.Parameters.AddWithValue("@modelo", model);
            cmd.Parameters.AddWithValue("@placa", plate);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@año", year);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        public void Edit_Bus(string brand, string model, string plate, string color, string year, int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Editar_Bus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@marca", brand);
            cmd.Parameters.AddWithValue("@modelo", model);
            cmd.Parameters.AddWithValue("@placa", plate);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@año", year);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        public void Delete_Bus(int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Eliminar_Bus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

    }
}
