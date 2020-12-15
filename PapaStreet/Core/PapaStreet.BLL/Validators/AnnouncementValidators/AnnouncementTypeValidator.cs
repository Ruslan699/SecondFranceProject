using FluentValidation;
using PapaStreet.BLL.DTOs;

namespace PapaStreet.BLL.Validators
{
    public class AnnouncementTypeValidator : AbstractValidator<AnnouncementTypeDto>
    {
        public AnnouncementTypeValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
        }
    }
}
