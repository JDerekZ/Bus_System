using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Entity
    {

        private string _id = null;
        private string _brand_status;
        private string _color_status;
        private string _cache_bus;
        private string _cache_route;


        public string Id { get => _id; set => _id = value; }
        public string Brand_status { get => _brand_status; set => _brand_status = value; }
        public string Color_status { get => _color_status; set => _color_status = value; }
        public string Cache_bus { get => _cache_bus; set => _cache_bus = value; }
        public string Cache_route { get => _cache_route; set => _cache_route = value; }
    }
}
