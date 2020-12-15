using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Models
{
    public class SaveAnnouncementImageViewModel:BaseViewModel
    {
        [Required]
        public Guid AnnouncementId { get; set; }

        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}