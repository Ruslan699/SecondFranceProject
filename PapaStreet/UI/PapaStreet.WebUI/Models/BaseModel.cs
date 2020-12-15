using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}