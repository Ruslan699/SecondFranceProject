using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class PricePlanDto : BaseDto
    {
        public Guid FrequencyId { get; set; }
        public Guid DurationId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AnnouncementCount { get; set; }
        public int BonusAnnouncementCount { get; set; }
        public string Description { get; set; }

        public FrequencyDto Frequency { get; set; }

        public FrequencyDto Duration { get; set; }
    }
}
