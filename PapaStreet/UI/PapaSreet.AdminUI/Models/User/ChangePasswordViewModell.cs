using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Models
{
    public class ChangePasswordViewModell
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceName = nameof(UI.CannotBeEmpty), ErrorMessageResourceType = typeof(UI))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(UI.ConfirmPasswordNotEqualsNewPassword), ErrorMessageResourceType = typeof(UI))]
        public string ConfirmPassword { get; set; }
    }
}