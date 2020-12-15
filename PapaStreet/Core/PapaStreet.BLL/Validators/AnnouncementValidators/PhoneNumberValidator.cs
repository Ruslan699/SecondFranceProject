using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumberDto>
    {
        public PhoneNumberValidator()
        {
            RuleFor(r => r.AnnouncementId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(r => r.Number).NotEmpty();
        }
    }
}
