using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("AnnouncementImages")]
    public class AnnouncementImageDao : BaseDao
    {
        public Guid AnnouncementId { get; set; }
        public byte[] Image { get; set; }

        [ForeignKey(nameof(AnnouncementId))]
        public AnnouncementDao Announcement { get; set; }

    }
}
