using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(m => m.CityId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.AnnouncementTypeId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.PropertyTypeId).NotEmpty().Must(r => r != default(Guid));
            
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.ContactPerson).NotEmpty();
            RuleFor(r => r.Amount).NotEmpty();
            RuleFor(r => r.Address).NotEmpty();
            RuleFor(r => r.Area).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.PropertyDescription).NotEmpty();
            RuleFor(r => r.VendorType).NotEmpty();
        }
    }
}
