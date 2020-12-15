using FluentValidation;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage(UI.CannotBeEmpty);
            RuleFor(r => r.LastName).NotEmpty().WithMessage(UI.CannotBeEmpty);
            RuleFor(r => r.Email).NotEmpty().WithMessage(UI.CannotBeEmpty);
            RuleFor(r => r.Email).EmailAddress().WithMessage(UI.InvalidEmail);
            RuleFor(r => r.Password).NotEmpty().WithMessage(UI.CannotBeEmpty);
        }
    }
}
