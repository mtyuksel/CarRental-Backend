using CarRental.Business.Constants;
using CarRental.Entity.Concrete;
using FluentValidation;
using System.Linq;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();

            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
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
