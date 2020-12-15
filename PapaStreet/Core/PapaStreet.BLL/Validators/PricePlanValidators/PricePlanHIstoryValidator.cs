using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class PricePlanHIstoryValidator : AbstractValidator<PricePlanHistoryDto>
    {
        public PricePlanHIstoryValidator()
        {
            RuleFor(m => m.CustomerId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.FromPricePlanId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(m => m.ToPricePlanId).NotEmpty().Must(r => r != default(Guid));
            RuleFor(r => r.StartDate).NotEmpty();
            RuleFor(r => r.EndDate).NotEmpty();
            RuleFor(r => r.UsedAnnouncementCount).NotEmpty();
        }
    }
}
