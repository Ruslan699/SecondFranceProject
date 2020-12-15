using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PapaSreet.AdminUI.Models
{
    public class CustomerViewModel:BaseViewModel
    {
        public CustomerViewModel()
        {
            CustomerNumbers = new HashSet<CustomerPhoneViewModel>();
        }
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string About { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public byte[] Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.InvalidEmail))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(UI.InvalidConfirmPassword), ErrorMessageResourceType = typeof(UI))]
        public string ConfirmNewPassword { get; set; }

        public Guid? PricePlanId { get; set; }
        public PricePlanDto PricePlan { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Password { get; set; }

        public ICollection<CustomerPhoneViewModel> CustomerNumbers { get; set; }
    }
}