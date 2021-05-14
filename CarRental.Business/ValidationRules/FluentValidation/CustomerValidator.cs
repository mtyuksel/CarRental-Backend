using CarRental.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserID).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(2).When(c => c.CompanyName != null);
        }
    }
}
