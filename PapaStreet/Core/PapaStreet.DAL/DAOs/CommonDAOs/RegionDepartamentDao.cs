using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("RegionDepartaments")]
    public class RegionDepartamentDao : BaseDao
    {
        public Guid RegionId { get; set; }
        public Guid DepartamentId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public RegionDao Region { get; set; }

        [ForeignKey(nameof(DepartamentId))]
        public DepartamentDao Departament { get; set; }
    }
}
