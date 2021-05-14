using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this._rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var existRental = _rentalDal.GetAll(r => r.CarID == rental.CarID).OrderBy(r => r.RentDate).FirstOrDefault();

            if (existRental == null || (existRental.ReturnDate != null && existRental.ReturnDate < DateTime.Now))
            {
                _rentalDal.Add(rental);

                return new SuccessResult(Messages.SuccesfullyAdded);
            }

            return new ErrorResult(Messages.CarHasNotYetBeenReturned);
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
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
