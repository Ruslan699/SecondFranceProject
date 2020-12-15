using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("PhoneNumbers")]
    public class PhoneNumberDao : BaseDao
    {
        public Guid AnnouncementId { get; set; }
        public string Number { get; set; }

        [ForeignKey(nameof(AnnouncementId))]
        public AnnouncementDao Announcement { get; set; }
    }
}
