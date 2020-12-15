using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Models
{
    public class AnnouncementViewModel : BaseViewModel
    {
        public AnnouncementViewModel()
        {
            AnnouncementImages = new HashSet<AnnouncementImageViewModel>();
            PhoneNumbers = new HashSet<PhoneNumberViewModel>();
        }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid AnnouncementTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid PropertyTypeId { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string ContactPerson { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.InvalidEmail))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public VendorType VendorType { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,3})?%?$", ErrorMessage = "Please enter valid Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string PropertyDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Address { get; set; }

        public string AnnouncementAddition { get; set; }
        public string[] AnnouncementAdditionals { get; set; }
        public List<string> AnnouncementAdditionalNames { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,3})?%?$", ErrorMessage = "Please enter valid Area")]
        public decimal Area { get; set; }
        public int RoomCount { get; set; }
        public int FloorCount { get; set; }
        public int CurrentFloor { get; set; }
        public int ViewsCount { get; private set; } = 0;
        public string Title { get; set; }
        public SourceType SourceType { get; set; }
        public ICollection<AnnouncementImageViewModel> AnnouncementImages { get; set; }
        public ICollection<PhoneNumberViewModel> PhoneNumbers { get; set; }

        public CityViewModel City { get; set; }
        public AnnouncementTypeViewModel AnnouncementType { get; set; }
        public PropertyTypeViewModel PropertyType { get; set; }
        public DocumentTypeViewModel DocumentType { get; set; }
        public RepairViewModel Repair { get; set; }
        public DepartmentViewModel Department { get; set; }
        //public RegionViewModel Region { get; set; }
       
    }
}