using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PapaStreet.WebUI.Models
{
    public class AnnouncementImageModel : BaseModel
    {
        public int Index { get; set; }
        public byte[] Image { get; set; }
        public Guid AnnouncementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public HttpPostedFileBase HttpPostedFileBase { get; set; }

        public string Base64StringImage => string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Image));

    }
}
