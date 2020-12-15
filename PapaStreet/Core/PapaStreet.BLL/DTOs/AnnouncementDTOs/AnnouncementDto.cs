using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.DTOs
{
    public class AnnouncementDto : BaseDto
    {
        public AnnouncementDto()
        {
            PhoneNumbers = new HashSet<PhoneNumberDto>();
            AnnouncementImages = new HashSet<AnnouncementImageDto>();
        }

        public Guid CityId { get; set; }
        public Guid AnnouncementTypeId { get; set; }
        public Guid PropertyTypeId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid RepairId { get; set; }

        public string Title { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public VendorType VendorType { get; set; }
        public string VendorTypeName => VendorType.ToString();
        public decimal Amount { get; set; }
        public string PropertyDescription { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int RoomCount { get; set; }
        public int FloorCount { get; set; }
        public int CurrentFloor { get; set; }
        public string CurrentFloorName { get; set; }
        public int ViewsCount { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public SourceType SourceType { get; set; }
        public string SourceTypeName => SourceType.ToString();
        public string AnnouncementAddition { get; set; }

        public ICollection<AnnouncementImageDto> AnnouncementImages { get; set; }
        public ICollection<PhoneNumberDto> PhoneNumbers { get; set; }

        public CityDto City { get; set; }
        public AnnouncementTypeDto AnnouncementType { get; set; }
        public PropertyTypeDto PropertyType { get; set; }
        public DocumentTypeDto DocumentType { get; set; }
        public RepairDto Repair { get; set; }

    }
}
