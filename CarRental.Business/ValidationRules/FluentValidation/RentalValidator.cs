using CarRental.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.CarID).NotEmpty();
            RuleFor(x => x.CustomerID).NotEmpty();
            RuleFor(x => x.RentDate).NotEmpty();
        }
    }
}
