using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;

namespace CarRental.Business.Logics
{
    public class CarImageLogics
    {
        //public static IResult CheckIfNumberOfImagesOfCarMax(ICarImageDal carImageDal,int carID)
        //{
        //    var result = carImageDal.GetAll(c => c.CarID == carID);

        //    return result.Count < 5 ? new SuccessResult() : new ErrorResult(Messages.CarImageLimitExceeded); 
        //}

        public static IResult CheckIfImagePathUnique(ICarImageDal carImageDal, string imagePath)
        {
            var result = carImageDal.Get(c => c.ImagePath == imagePath);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.CarImageLimitExceeded);
        }
    }
}
