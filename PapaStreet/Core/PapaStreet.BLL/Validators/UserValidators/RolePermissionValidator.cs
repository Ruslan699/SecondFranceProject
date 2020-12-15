using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class RolePermissionValidator : AbstractValidator<RolePermissionDto>
    {
        public RolePermissionValidator()
        {
            RuleFor(m => m.RoleId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
            RuleFor(m => m.Permission).NotEmpty();
        }
    }
}
