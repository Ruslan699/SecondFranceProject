using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("DocumentTypes")]
    public class DocumentTypeDao : BaseDao
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
