using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("Frequencies")]
    public class FrequencyDao : BaseDao
    {
        public string Name { get; set; }
        public int DaysCount { get; set; }
        public string Description { get; set; }
    }
}
