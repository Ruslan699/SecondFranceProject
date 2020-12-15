using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LesagencesPropertyService
{
    public class PropertyModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public int? RoomsCount { get; set; }
        public string Address { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? TotalSquare { get; set; }
        public Guid? ImageId { get; set; }
    }
}