using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string ZipCodeAndName { get; set; }
        public string Description { get; set; }
    }
}
