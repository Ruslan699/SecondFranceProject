using System;

namespace PapaStreet.BLL.DTOs
{
    public class AnnouncementImageDto : BaseDto
    {
        public Guid AnnouncementId { get; set; }
        public byte[] Image { get; set; }
        public string Base64StringImage => string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Image));
        public AnnouncementDto Announcement { get; set; }

    }
}
