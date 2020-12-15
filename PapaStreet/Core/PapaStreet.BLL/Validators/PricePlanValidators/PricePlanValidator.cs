using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class PricePlanValidator: AbstractValidator<PricePlanDto>
    {
        public PricePlanValidator()
        {
            RuleFor(m => m.FrequencyId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.DurationId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Price).NotEmpty();
            RuleFor(r => r.AnnouncementCount).NotEmpty();
            RuleFor(r => r.BonusAnnouncementCount).GreaterThanOrEqualTo(0);
            RuleFor(r => r.Description).NotEmpty();
        }
    }
}
