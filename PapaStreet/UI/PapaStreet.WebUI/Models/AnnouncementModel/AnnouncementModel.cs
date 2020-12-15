using PapaStreet.Common.Resources;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Models
{
    public class AnnouncementModel : BaseModel
    {
        public AnnouncementModel()
        {
            AnnouncementImages = new HashSet<AnnouncementImageModel>();

            PhoneNumbers = new HashSet<PhoneNumberModel>();
        }
        
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid AnnouncementTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid PropertyTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string ContactPerson { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.InvalidEmail))]
        public string Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = nameof(UI.CannotBeEmpty))]
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public VendorType VendorType { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^[1-9]\d{1,9}(\.\d{1,3})?%?$", ErrorMessage = "Please enter valid Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string PropertyDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^[1-9]\d{1,9}(\.\d{1,3})?%?$", ErrorMessage = "Please enter valid Area")]
        public decimal Area { get; set; }
        public int RoomCount { get; set; }
        public int FloorCount { get; set; }
        public int CurrentFloor { get; set; }
        public string CurrentFloorName { get; set; }
        public int ViewsCount { get; private set; } = 0;
        public string Title { get; set; }
        public string AnnouncementAddition { get; set; }
        public List<string> AnnouncementAdditionals { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public SourceType SourceType { get; set; }
        public ICollection<AnnouncementImageModel> AnnouncementImages { get; set; }
        public ICollection<PhoneNumberModel> PhoneNumbers { get; set; }

        public CityModel City { get; set; }
        public AnnouncementTypeModel AnnouncementType { get; set; }
        public PropertyTypeModel PropertyType { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public RepairModel Repair { get; set; }

        public Pager Pager { get; set; }
    }
}