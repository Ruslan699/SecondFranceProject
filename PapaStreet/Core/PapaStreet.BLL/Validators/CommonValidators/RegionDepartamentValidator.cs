using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class RegionDepartamentValidator : AbstractValidator<RegionDepartamentDto>
    {
        public RegionDepartamentValidator()
        {
            RuleFor(m => m.RegionId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.DepartamentId).NotEmpty().Must(r => r != default(Guid));
        }
    }
}
