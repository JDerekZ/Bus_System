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
    public class CD_Route
    {

        private DB_Connect connect = new DB_Connect();

        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable viewAll()
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Listar_Rutas";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }

        //For Add or Create
        public void Create_Route(string new_Route)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Crear_Ruta";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@new_ruta", new_Route);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        public void Edit_Route(string new_Route, int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Editar_Rutas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@new_ruta", new_Route);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        public void Delete_Route(int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Eliminar_Ruta";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

    }
}
