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
    public class CD_Chofer
    {
        private DB_Connect connect = new DB_Connect();

        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();


        //for List
        public DataTable viewAll()
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Listar_Choferes";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }

        //For add
        public void Create_Chofer(int idBus, int idRuta, string name, string lastname, DateTime date, string idCard)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Crear_Chofer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idbus", idBus);
            cmd.Parameters.AddWithValue("@idruta", idRuta);
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@apellido", lastname);
            cmd.Parameters.AddWithValue("@fechaN", date);
            cmd.Parameters.AddWithValue("@cedula", idCard);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        //For Edit
        public void Edit_Chofer(int idBus, int idRuta, string name, string lastname, DateTime date, string idCard, int id)
        {

            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Edit_Chofer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idbus", idBus);
            cmd.Parameters.AddWithValue("@idruta", idRuta);
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@apellido", lastname);
            cmd.Parameters.AddWithValue("@fechaN", date);
            cmd.Parameters.AddWithValue("@cedula", idCard);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        //For Delete
        public void Delete_Chofer(int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Delete_Chofer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }

        //For Load Comobox Bus
        public DataTable LoadComboBus()
        {
            DataTable tableForBus = new DataTable();
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Cargar_ComboBus";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            tableForBus.Load(reader);
            reader.Close();
            connect.ClosedsqlConnection();

            return tableForBus;
        }

        public DataTable LoadComboRoute()
        {
            DataTable tableForRoute = new DataTable();
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Cargar_ComboRuta";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            tableForRoute.Load(reader);
            reader.Close();
            connect.ClosedsqlConnection();

            return tableForRoute;
        }


        //public bool Search(int bus, int route) 
        //{
        //    cmd.Connection = connect.OpensqlConnection();
        //    cmd.CommandText = "SP_Buscar";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@bus", bus);
        //    cmd.Parameters.AddWithValue("@ruta", route);
        //    reader = cmd.ExecuteReader();            
        //    connect.ClosedsqlConnection();

        //    return true;
        //}

        public DataTable viewAssig()
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Listar_Asignacion";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }

    }
}
