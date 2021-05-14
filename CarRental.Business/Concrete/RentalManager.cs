using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        private ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            this._rentalDal = rentalDal;
            this._carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                RentalLogics.CheckIfCarExistForGivenID(_carService, rental.CarID),
                RentalLogics.CheckIfCustomerExistForGivenID(_customerService, rental.CustomerID),
                RentalLogics.CheckIfCarAlreadyRented(_rentalDal, rental)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByID(int ID)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.ID == ID));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(
                RentalLogics.CheckIfCarExistForGivenID(_carService, rental.CarID),
                RentalLogics.CheckIfCustomerExistForGivenID(_customerService, rental.CustomerID)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
