using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Logics
{
    internal class ColorLogics
    {
        public static IResult CheckIfColorAlreadyExist(IColorDal colorDal, Color color)
        {
            var result = colorDal.Get(c => c.Name == color.Name);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.AlreadyExist("color"));
        }
    }
}
