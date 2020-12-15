using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class RegionDepartamentDto : BaseDto
    {
        public Guid RegionId { get; set; }
        public Guid DepartamentId { get; set; }

        public RegionDto Region { get; set; }
        public DepartamentDto Departament { get; set; }
    }
}
