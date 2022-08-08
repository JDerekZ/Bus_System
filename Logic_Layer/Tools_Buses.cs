using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Data_Layer;

namespace Logic_Layer
{
    public class Tools_Buses
    {
        CD_Bus cD_Bus = new CD_Bus();

        //List Method
        public DataTable ViewAllBuses()
        {
            DataTable table = new DataTable();
            table = cD_Bus.viewAll();
            return table;
        }

        //Create Method
        public void Create_Buses(string brand, string model, string plate, string color, string year)
        {

            cD_Bus.Create_Bus(brand, model, plate, color, year);

        }

        //Edit Method
        public void Edit_Buses(string brand, string model, string plate, string color, string year, string Id)
        {

            cD_Bus.Edit_Bus(brand, model, plate, color, year, Convert.ToInt32(Id));

        }

        //Delete Logic Method
        public void Delete_Buses(string Id)
        {

            cD_Bus.Delete_Bus(Convert.ToInt32(Id));

        }

    }
}
