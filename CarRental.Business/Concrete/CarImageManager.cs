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
                CarImageLogics.CheckIfNumberOfImagesOfCarMax(_carImageDal, carImage.CarID),
                CarImageLogics.CheckIfImagePathUnique(_carImageDal, carImage.ImagePath)
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

            if (existsImage == null)
            {
                return new ErrorResult(Messages.ImagePathNotFound);
            }

            _carImageDal.Delete(existsImage);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<string>> GetAllImagePathsByCarID(int carID)
        {
            var result = _carImageDal.GetImagePathsByCarID(carID);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<string>>(Messages.NotFound("images"));
            }

            return new SuccessDataResult<List<string>>(result);
        }


        public IDataResult<CarImage> GetByID(int ID)
        {
            var result = _carImageDal.Get(c => c.ID == ID);

            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }

            return new ErrorDataResult<CarImage>(Messages.CarNotFound);
        }

        public IDataResult<CarImage> GetByImagePath(string imagePath)
        {
            var result = _carImageDal.Get(c => c.ImagePath == imagePath);

            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }

            return new ErrorDataResult<CarImage>(Messages.ImagePathNotFound);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(
                _carService.CheckIfCarExists(carImage.CarID),
                CarImageLogics.CheckIfImagePathUnique(_carImageDal, carImage.ImagePath));

            if (!result.Success)
            {
                return result;
            }

            var existsCar = _carImageDal.Get(c => c.ImagePath == carImage.ImagePath && c.CarID == carImage.CarID);
            _carImageDal.Update(existsCar);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
