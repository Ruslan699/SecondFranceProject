using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class PhoneNumberDto : BaseDto
    {
        public Guid AnnouncementId { get; set; }
        public string Number { get; set; }

        public AnnouncementDto Announcement { get; set; }
    }
}
