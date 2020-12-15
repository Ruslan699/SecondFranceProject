using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class PricePlanHistoryDto :BaseDto
    {
        public Guid CustomerId { get; set; }
        public Guid FromPricePlanId { get; set; }
        public Guid ToPricePlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsedAnnouncementCount { get; set; }

        public CustomerDto Customer { get; set; }
        public PricePlanDto ToPricePlan { get; set; }
        public PricePlanDto FromPricePlan { get; set; }

    }
}
