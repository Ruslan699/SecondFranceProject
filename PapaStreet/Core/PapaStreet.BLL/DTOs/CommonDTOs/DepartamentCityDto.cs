using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class DepartamentCityDto : BaseDto
    {
        public Guid DepartamentId { get; set; }
        public Guid CityId { get; set; }

        public DepartamentDto Departament { get; set; }
        public CityDto City { get; set; }
    }
}
