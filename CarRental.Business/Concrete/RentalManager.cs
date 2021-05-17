using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [SecuredOperation("admin,salesPerson,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IResult> Add(Rental rental)
        {
            var result = BusinessRules.Run(
                RentalLogics.CheckIfCarExistForGivenID(_carService, rental.CarID),
                RentalLogics.CheckIfCustomerExistForGivenID(_customerService, rental.CustomerID)
                //RentalLogics.CheckIfCarAlreadyRented(_rentalDal, rental)
                );

            if (result != null)
            {
                return result;
            }

            await _rentalDal.Add(rental);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IResult> Delete(Rental rental)
        {
            await _rentalDal.Delete(rental);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public async Task<IDataResult<List<Rental>>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAll());
        }

        public async Task<IDataResult<Rental>> GetByID(int ID)
        {
            return new SuccessDataResult<Rental>(await _rentalDal.Get(r => r.ID == ID));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IResult> Update(Rental rental)
        {
            var result = BusinessRules.Run(
                RentalLogics.CheckIfCarExistForGivenID(_carService, rental.CarID),
                RentalLogics.CheckIfCustomerExistForGivenID(_customerService, rental.CustomerID)
                );

            if (result != null)
            {
                return result;
            }

            await _rentalDal.Update(rental);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
