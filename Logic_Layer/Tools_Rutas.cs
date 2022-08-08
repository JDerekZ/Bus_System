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
    public class Tools_Rutas
    {
        CD_Route cD_Routes = new CD_Route();
        
        //List Method
        public DataTable ViewAllRoutes()
        {
            DataTable table = new DataTable();
            table = cD_Routes.viewAll();
            return table;
        }

        //Create Method
        public void Create_Routes(string new_route)
        { 
        
            cD_Routes.Create_Route(new_route);
        
        }

        //Edit Method
        public void Edit_Routes(string new_route, string Id)
        { 
        
            cD_Routes.Edit_Route(new_route, Convert.ToInt32(Id));

        }

        //Delete Logic Method
        public void Delete_Routes(string Id)
        {

            cD_Routes.Delete_Route(Convert.ToInt32(Id));

        }

    }
}
