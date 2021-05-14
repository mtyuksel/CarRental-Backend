using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;

namespace CarRental.Business.Logics
{
    internal class CustomerLogics
    {
        public static IResult CheckIfCustomerAlreadyExist(ICustomerDal customerDal, Customer customer)
        {
            var result = customerDal.Get(c => c.CompanyName == customer.CompanyName);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.AlreadyExist("customer"));
        }
    }
}
