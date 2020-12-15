using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class DepartamentCityValidator : AbstractValidator<DepartamentCityDto>
    {
        public DepartamentCityValidator()
        {
            RuleFor(m => m.DepartamentId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.CityId).NotEmpty().Must(r => r != default(Guid));
        }
    }
}
