using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.Models
{
    public class CustomerModel : BaseModel
    {
        public CustomerModel()
        {
            CustomerNumbers = new HashSet<CustomerPhoneNumberModel>();
        }
        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string LastName { get; set; }
        public byte[] Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessageResourceType =typeof(UI),ErrorMessageResourceName =nameof(UI.InvalidEmail))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(UI.InvalidConfirmPassword), ErrorMessageResourceType = typeof(UI))]
        public string ConfirmNewPassword { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        [Compare(nameof(Password),ErrorMessageResourceName = nameof(UI.InvalidConfirmPassword), ErrorMessageResourceType = typeof(UI))]
        public string ConfirmPassword { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public Guid PricePlanId { get; set; }
        public PricePlanDto PricePlan { get; set; }
        public bool PricePlanStatus { get; set; }
        public ICollection<CustomerPhoneNumberModel> CustomerNumbers { get; set; }
    }
}