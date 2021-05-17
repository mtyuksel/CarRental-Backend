using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Performance;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public async Task<IResult> Add(CarImage carImage)
        {
            var result = BusinessRules.Run(
                await _carService.CheckIfCarExists(carImage.CarID),
                CarImageLogics.CheckIfImagePathUnique(_carImageDal, carImage.ImagePath)
                );

            if (!result.Success)
            {
                return result;
            }

            await _carImageDal.Add(carImage);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public async Task<IResult> Delete(CarImage carImage)
        {
            var existsImage = await _carImageDal.Get(c => c.CarID == carImage.CarID && c.ImagePath == carImage.ImagePath);

            if (existsImage == null)
            {
                return new ErrorResult(Messages.ImagePathNotFound);
            }

            await _carImageDal.Delete(existsImage);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }
                
        [CacheAspect]
        public async Task<IDataResult<List<CarImage>>> GetAll()
        {
            throw new System.NotImplementedException();
        }


        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<List<string>>> GetAllImagePathsByCarID(int carID)
        {
            var result = await _carImageDal.GetImagePathsByCarID(carID);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<string>>(Messages.NotFound("images"));
            }

            return new SuccessDataResult<List<string>>(result);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public async Task<IDataResult<CarImage>> GetByID(int ID)
        {
            var result = await _carImageDal.Get(c => c.ID == ID);

            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }

            return new ErrorDataResult<CarImage>(Messages.CarNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(5)]
        public async Task<IDataResult<CarImage>> GetByImagePath(string imagePath)
        {
            var result = await _carImageDal.Get(c => c.ImagePath == imagePath);

            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }

            return new ErrorDataResult<CarImage>(Messages.ImagePathNotFound);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageManager.Get")]
        public async Task<IResult> Update(CarImage carImage)
        {
            var result = BusinessRules.Run(
                await _carService.CheckIfCarExists(carImage.CarID),
                CarImageLogics.CheckIfImagePathUnique(_carImageDal, carImage.ImagePath));

            if (!result.Success)
            {
                return result;
            }

            var existsCar = await _carImageDal.Get(c => c.ImagePath == carImage.ImagePath && c.CarID == carImage.CarID);
            await _carImageDal.Update(existsCar);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
