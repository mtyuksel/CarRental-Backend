using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;

namespace CarRental.Business.Logics
{
    internal class CarLogics
    {
        public static IResult CheckIfCarNotExists(ICarDal carDal ,Car car)
        {
            var result = carDal.Get(c => c.BrandID == car.BrandID
           && c.ColorID == car.ColorID
           && c.ModelYear == car.ModelYear
           && c.Name == car.Name);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.AlreadyExist("car"));
        }
        
        public static IResult CheckIfCarExists(ICarDal carDal ,Car car)
        {
            var result = carDal.Get(c => c.BrandID == car.BrandID
           && c.ColorID == car.ColorID
           && c.ModelYear == car.ModelYear
           && c.Name == car.Name);

            return result != null ? new SuccessResult() : new ErrorResult(Messages.NotExist("car"));
        }

        public static IResult CheckIfCarCountOfBrandCorrect(ICarDal carDal, int brandID)
        {
            var result = carDal.GetAll(c => c.BrandID == brandID);

            return result.Count <= 3 ? new SuccessResult() : new ErrorResult(Messages.CountOfCarForBrandError);
        }

        public static IResult CheckIfSystemAtMaintenanceTime() => DateTime.Now.Hour == 8 ? new ErrorResult(Messages.MaintenanceTime) : new SuccessResult();
    }
}
