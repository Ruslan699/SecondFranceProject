using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class FrequencyValidator : AbstractValidator<FrequencyDto>
    {
        public FrequencyValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.DaysCount).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
        }
    }
}
