using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.Models
{
    public class RegionDepartamentModel : BaseModel
    {
        public Guid RegionId { get; set; }
        public Guid DepartamentId { get; set; }

        public RegionModel Region { get; set; }
        public DepartamentModel Departament { get; set; }
    }
}