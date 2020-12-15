using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Models
{
    public class AnnouncementImageViewModel:BaseViewModel
    {
        public int Index { get; set; }
        public byte[] Image { get; set; }
        public Guid AnnouncementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public HttpPostedFileBase HttpPostedFileBase { get; set; }

        public string Base64StringImage => string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Image));
    }
}