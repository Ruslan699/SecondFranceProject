using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.Models
{
    public class DepartamentCityModel : BaseModel
    {
        public Guid CityId { get; set; }
        public Guid DepartamentId { get; set; }

        public RegionModel Region { get; set; }
        public CityModel City { get; set; } 
    }
}