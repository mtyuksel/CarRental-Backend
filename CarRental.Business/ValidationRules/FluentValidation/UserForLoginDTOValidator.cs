using CarRental.Business.Constants;
using CarRental.Entity.DTOs;
using FluentValidation;
using System.Linq;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class UserForLoginDTOValidator : AbstractValidator<UserForLoginDTO>
    {
        public UserForLoginDTOValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
