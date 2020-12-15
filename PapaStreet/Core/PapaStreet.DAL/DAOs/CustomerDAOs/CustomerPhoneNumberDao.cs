using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("CustomerPhones")]
    public class CustomerPhoneNumberDao : BaseDao
    {
        public Guid CustomerId { get; set; }
        public string Number { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerDao Customer { get; set; }
    }
}
