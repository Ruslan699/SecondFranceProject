using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("DepartamentCities")]
    public class DepartamentCityDao : BaseDao
    {
        public Guid DepartamentId { get; set; }
        public Guid CityId { get; set; }

        [ForeignKey(nameof(DepartamentId))]
        public DepartamentDao Departament { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityDao City { get; set; }
    }
}
