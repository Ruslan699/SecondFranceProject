using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DAOs
{
    [Table("GenericAnnouncements")]
    public class GenericAnnouncementDao  : BaseDao
    {
        public string HostSite { get; set; }
        public string ExternalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Images { get; set; }
        public string ThumbImages { get; set; }
        public string SmallImages { get; set; }
        public string LargeUrls { get; set; }

        public string Price { get; set; }
        public string First_Publication_Date { get; set; }
        public string Expiration_Date { get; set; }
        public string Category_Id { get; set; }
        public string Category_Name { get; set; }
        public string LinkUrl { get; set; }
        public string Extra { get; set; }
        public Guid? AnnouncementTypeId { get; set; }
        public Guid? PropertyTypeId { get; set; }
        public decimal? Area { get; set; }
        public int? RoomCount { get; set; }
        public int? FloorCount { get; set; }
        public int? CurrentFloor { get; set; }
        public string AnnouncementAddition { get; set; }
        public string LinkText { get; set; }
        public string City { get; set; }
        public double? Latitude { get; set; }
        public double? Langitude { get; set; }
        public string Region { get; set; }
        public SourceType SourceType { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? PriceDouble { get; set; }

        [ForeignKey(nameof(AnnouncementTypeId))]
        public AnnouncementTypeDao AnnouncementType { get; set; }

        [ForeignKey(nameof(PropertyTypeId))]
        public PropertyTypeDao PropertyType { get; set; }
    }
}
