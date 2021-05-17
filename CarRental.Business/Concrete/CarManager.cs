using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Transaction;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CarLogics.CheckIfCarNotExists(_carDal, car));

            if (!result.Success)
            {
                return result;
            }

            await _carDal.Add(car);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public async Task<IResult> Delete(Car car)
        {
            await _carDal.Delete(car);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Car>>> GetAll()
        {
            IResult result = BusinessRules.Run(CarLogics.CheckIfSystemAtMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }

            return new SuccessDataResult<List<Car>>(await _carDal.GetAll());
        }

        [CacheAspect]
        public async Task<IDataResult<Car>> GetByID(int ID)
        {
            return new SuccessDataResult<Car>(await _carDal.Get(c => c.ID == ID));
        }

        public async Task<IDataResult<List<CarDetailDTO>>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(await _carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public async Task<IResult> Update(Car car)
        {
            IResult result = BusinessRules.Run(
                CarLogics.CheckIfCarExists(_carDal, car));

            if (!result.Success)
            {
                return result;
            }

            await _carDal.Update(car);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }

        [TransactionScopeAspect]
        public async Task<IResult> CheckIfCarExists(int ID)
        {
            var result = await GetByID(ID);

            if (result.Data != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.NotExist("car"));
        }
    }
}
