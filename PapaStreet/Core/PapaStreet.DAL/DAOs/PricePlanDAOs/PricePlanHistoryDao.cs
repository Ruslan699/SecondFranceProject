using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("PricePlanHistories")]
    public class PricePlanHistoryDao :BaseDao
    {
        public Guid CustomerId { get; set; }
        public Guid FromPricePlanId { get; set; }
        public Guid ToPricePlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsedAnnouncementCount { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerDao Customer { get; set; }

        [ForeignKey(nameof(ToPricePlanId))]
        public PricePlanDao ToPricePlan { get; set; }

        [ForeignKey(nameof(FromPricePlanId))]
        public PricePlanDao FromPricePlan { get; set; }

    }
}
