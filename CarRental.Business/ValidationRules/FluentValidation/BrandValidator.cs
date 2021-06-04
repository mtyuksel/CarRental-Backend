using CarRental.Entity.Concrete;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).NotEqual("T");
        }
    }
}
