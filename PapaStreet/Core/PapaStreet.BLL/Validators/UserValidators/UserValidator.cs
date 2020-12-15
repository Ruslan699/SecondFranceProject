using FluentValidation;
using PapaStreet.BLL.DTOs;

namespace PapaStreet.BLL.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            //RuleFor(r => r.RoleId).NotEmpty().Must(r => r != default(Guid));
            //RuleFor(r => r.FirstName).NotEmpty();
            //RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().Must(Validate_PW);

        }

        private bool Validate_PW(string pw)
        {
            if (pw.Length < 8 && pw.Length > 15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
