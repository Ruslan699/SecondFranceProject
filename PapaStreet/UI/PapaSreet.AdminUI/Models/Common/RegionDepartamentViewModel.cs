using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Models
{
    public class RegionDepartamentViewModel:BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid RegionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(UI), ErrorMessageResourceName = nameof(UI.CannotBeEmpty))]
        public Guid DepartamentId { get; set; }

        public RegionViewModel Region { get; set; }
        public DepartmentViewModel Departament { get; set; }
    }
}