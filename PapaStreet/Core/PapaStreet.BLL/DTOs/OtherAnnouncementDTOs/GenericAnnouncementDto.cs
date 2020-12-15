using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.DTOs
{
    public class GenericAnnouncementDto : BaseDto
    {
        public string HostSite { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public List<string> Images { get; set; }

        public List<string> ThumbImages { get; set; }
        public List<string> SmallImages { get; set; }
        public List<string> LargeUrls { get; set; }

        public List<string> Price { get; set; }
        public string first_publication_date { get; set; }
        public string expiration_date { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string LinkUrl { get; set; }
        public object Extra { get; set; }
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
        public decimal? PriceDouble { get; set; }
        public AnnouncementTypeDto AnnouncementType { get; set; }
        public PropertyTypeDto PropertyType { get; set; }
    }
}
