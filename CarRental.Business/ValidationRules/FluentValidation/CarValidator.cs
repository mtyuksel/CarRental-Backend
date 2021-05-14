using CarRental.Business.Constants;
using CarRental.Entity.Concrete;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.BrandID).NotEmpty();
            RuleFor(c => c.ColorID).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2).WithMessage(Messages.ShouldGraterThan("Car Name Length", "2"));
            RuleFor(c => c.DailyPrice).GreaterThan(50).WithMessage(Messages.ShouldGraterThan("DailyPrice", "50"));
        }
    }
}
