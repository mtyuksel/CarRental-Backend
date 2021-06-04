using FluentValidation.Results;
using System.Collections.Generic;

namespace CarRental.Core.Entity.Concrete
{
    class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
