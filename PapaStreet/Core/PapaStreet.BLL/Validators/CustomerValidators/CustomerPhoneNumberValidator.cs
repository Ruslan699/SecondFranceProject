using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class CustomerPhoneNumberValidator : AbstractValidator<CustomerPhoneNumberDto>
    {
        public CustomerPhoneNumberValidator()
        {
            RuleFor(r => r.CustomerId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(r => r.Number).NotEmpty();
        }
    }
}
