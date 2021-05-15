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
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            this._carImageDal = carImageDal;
            this._carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(
                _carService.CheckIfCarExists(carImage.CarID),
                CarImageLogics.CheckIfNumberOfImagesOfCarMax(_carImageDal, carImage.CarID)
                );

            if (!result.Success)
            {
                return result;
            }

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var existsImage = _carImageDal.Get(c => c.CarID == carImage.CarID && c.ImagePath == carImage.ImagePath);
            _carImageDal.Delete(existsImage);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<CarImage> GetByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(_carService.CheckIfCarExists(carImage.CarID));

            if (!result.Success)
            {
                return result;
            }

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
