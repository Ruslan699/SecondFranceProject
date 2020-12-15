using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class FrequencyDto : BaseDto
    {
        public string Name { get; set; }
        public int DaysCount { get; set; }
        public string Description { get; set; }
    }
}
