using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Models
{
    public class PricePlanHistoryViewModel:BaseViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid FromPricePlanId { get; set; }
        public Guid ToPricePlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsedAnnouncementCount { get; set; }

        public IEnumerable<CustomerDto> Customers { get; set; }
        public IEnumerable<PricePlanDto> ToPricePlan { get; set; }
        public IEnumerable<PricePlanDto> FromPricePlan { get; set; }
    }
}