using PapaStreet.Common.Resources;
using System.ComponentModel.DataAnnotations;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Models
{
    public class PropertyTypeViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Description { get; set; }

        public Status Status { get; set; }
        public string StatusName => Status.ToString();
    }
}