using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs
{
    public class SearchDto
    {
        public Guid? announcementtype { get; set; }
        public Guid? PropertyTypes { get; set; }
        public Guid? repair { get; set; }
        public Guid? Regions { get; set; }
        public Guid? Departaments { get; set; }
        public List<Guid?> Cities { get; set; }
        public Guid? id { get; set; }
        public List<string> CityName { get; set; }
        public string AnnouncementAdditionId { get; set; }
        public int? minroomcount { get; set; }
        public int? maxroomcount { get; set; }
        public decimal? minprice { get; set; }
        public decimal? maxprice { get; set; }
        public decimal? minarea { get; set; }
        public decimal? maxarea { get; set; }
        public int? sortBy { get; set; }
        public int? page { get; set; }
    }
}
