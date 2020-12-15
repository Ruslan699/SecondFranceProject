using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ViewModels
{
    public class DepartamentCityViewModel
    {
        public IEnumerable<DepartamentDropDownViewModel> Departaments { get; set; }
        public IEnumerable<CityDropDownViewModel> Cities { get; set; }
    }
}