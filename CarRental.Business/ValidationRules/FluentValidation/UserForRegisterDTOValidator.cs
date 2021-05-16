using CarRental.Business.Constants;
using CarRental.Entity.DTOs;
using FluentValidation;
using System.Linq;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDTOValidator : AbstractValidator<UserForRegisterDTO>
    {
        public UserForRegisterDTOValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(PasswordStrong).WithMessage(Messages.PasswordNotStrongEnough);
        }

        private bool PasswordStrong(string password)
        {
            return password.Any(char.IsDigit)
                && password.Any(char.IsLetter)
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsSymbol);
        }
    }
}
