using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Logics
{
    internal class BrandLogics
    {
        public static IResult CheckIfBrandAlreadyExist(IBrandDal brandDal, Brand brand)
        {
            var result = brandDal.Get(c => c.Name == brand.Name);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.AlreadyExist("brand"));
        }
    }
}
