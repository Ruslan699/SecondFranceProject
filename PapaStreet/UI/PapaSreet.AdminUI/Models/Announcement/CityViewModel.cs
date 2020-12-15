using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Models
{
    public class CityViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string ZipCode { get; set; }
        

    }
}