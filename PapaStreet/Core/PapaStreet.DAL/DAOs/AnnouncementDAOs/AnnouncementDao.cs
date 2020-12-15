using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DAOs
{
    [Table("Announcements")]
    public class AnnouncementDao : BaseDao
    {
        public Guid CityId { get; set; }
        public Guid AnnouncementTypeId { get; set; }
        public Guid PropertyTypeId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid? RepairId { get; set; }

        public string Title { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public VendorType VendorType { get; set; }
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
        public string AnnouncementAddition { get; set; }
        public ICollection<AnnouncementImageDao> AnnouncementImages { get; set; }
        public ICollection<PhoneNumberDao> PhoneNumbers { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityDao City { get; set; }

        [ForeignKey(nameof(AnnouncementTypeId))]
        public AnnouncementTypeDao AnnouncementType { get; set; }

        [ForeignKey(nameof(PropertyTypeId))]
        public PropertyTypeDao PropertyType { get; set; }

        [ForeignKey(nameof(DocumentTypeId))]
        public DocumentTypeDao DocumentType { get; set; }

        [ForeignKey(nameof(RepairId))]
        public RepairDao Repair { get; set; }

    }
}
