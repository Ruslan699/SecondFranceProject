using PapaStreet.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace PapaSreet.AdminUI.Models
{
    public class DepartmentViewModel:BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public string Description { get; set; }
    }
}