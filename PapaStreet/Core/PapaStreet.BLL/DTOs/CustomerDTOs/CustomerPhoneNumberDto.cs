using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    [Table("CustomerPhones")]
    public class CustomerPhoneNumberDto : BaseDto
    {
        public Guid CustomerId { get; set; }
        public string Number { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerDto Customer { get; set; }
    }
}
