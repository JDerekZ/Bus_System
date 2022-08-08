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
    public class Tools_Chofer
    {

        CD_Chofer cD_Chofer = new CD_Chofer();


        //Logic Method List Choferes
        public DataTable ViewAllChoferes()
        {
            DataTable table = new DataTable();
            table = cD_Chofer.viewAll();
            return table;
        }

        //Logic Method to Add or Create Chofer
        public void Create_Chofer(int idBus, int idRuta, string name, string lastname, DateTime date_time, string idCard)
        {

            cD_Chofer.Create_Chofer(idBus, idRuta, name, lastname, date_time, idCard);

        }
        
        //Edit Logic Method
        public void Edit_Chofer(int idBus, int idRuta, string name, string lastname, DateTime date_time, string idCard, string Id)
        {

            cD_Chofer.Edit_Chofer(idBus, idRuta, name, lastname, date_time, idCard, Convert.ToInt32(Id));

        }

        //Delete Logic Method
        public void Delete_Chofer(string Id)
        {

            cD_Chofer.Delete_Chofer(Convert.ToInt32(Id));

        }


        //Return function
        public DataTable LoadComboBus()
        {
            return cD_Chofer.LoadComboBus();
        }

        //Return function
        public DataTable LoadComboRoute()
        {
            return cD_Chofer.LoadComboRoute();
        }

        //public bool SearchBus(int bus)
        //{
        //    if (cD_Chofer.SearchBus(bus))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }                    
        //}

        //public bool SearchRoute(int route)
        //{
        //    if (cD_Chofer.SearchRoute(route))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool Search(int bus, int route)
        //{
        //    if (cD_Chofer.Search(bus, route))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //LIST INNERJOIN
        public DataTable ViewInnerJoin()
        {
            DataTable table = new DataTable();
            table = cD_Chofer.viewAssig();
            return table;
        }
    }
}
