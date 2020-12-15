using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("PricePlans")]
    public class PricePlanDao : BaseDao
    {
        public Guid FrequencyId { get; set; }
        public Guid DurationId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AnnouncementCount { get; set; }
        public int BonusAnnouncementCount { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(FrequencyId))]
        public FrequencyDao Frequency { get; set; }

        [ForeignKey(nameof(DurationId))]
        public FrequencyDao Duration { get; set; }
    }
}
