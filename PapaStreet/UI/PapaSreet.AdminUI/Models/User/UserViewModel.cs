using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Models
{
    public class UserViewModel: BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.InvalidEmail))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string Password { get; set; }

        public string UserName { get; set; }
    }
}