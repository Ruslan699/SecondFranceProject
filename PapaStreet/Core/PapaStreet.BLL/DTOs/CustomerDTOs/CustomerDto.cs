using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class CustomerDto : BaseDto
    {
        public Guid PricePlanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<CustomerPhoneNumberDto> CustomerNumbers { get; set; }

        public PricePlanDto PricePlan { get; set; }
    }
}
