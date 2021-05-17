using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;
using System.Linq;

namespace CarRental.Business.Logics
{
    internal class RentalLogics
    {
        public static IResult CheckIfCarExistForGivenID(ICarService carService, int ID)
        {
            var result = carService.GetByID(ID);

            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.NotExist("car"));
        }
        
        public static IResult CheckIfCustomerExistForGivenID(ICustomerService customerService, int ID)
        {
            var result = customerService.GetByID(ID);

            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.NotExist("customer"));
        }

        //public static IResult CheckIfCarAlreadyRented(IRentalDal rentalDal, Rental rental)
        //{
        //    var existRental = rentalDal.GetAll(r => r.CarID == rental.CarID).OrderBy(r => r.RentDate).FirstOrDefault();

        //    if (existRental == null || (existRental.ReturnDate != null && existRental.ReturnDate < DateTime.Now))
        //    {
        //        return new SuccessResult();
        //    }

        //    return new ErrorResult(Messages.CarAlreadyRented);
        //}
    }
}
