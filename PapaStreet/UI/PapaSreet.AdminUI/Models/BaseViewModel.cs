using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Models
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
    }
}