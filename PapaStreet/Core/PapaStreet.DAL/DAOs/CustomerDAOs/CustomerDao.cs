using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("Customers")]
    public class CustomerDao : BaseDao
    {
        public Guid PricePlanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<CustomerPhoneNumberDao> CustomerNumbers { get; set; }

        [ForeignKey(nameof(PricePlanId))]
        public PricePlanDao PricePlan { get; set; }
    }
}
