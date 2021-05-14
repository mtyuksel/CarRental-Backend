using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;

namespace CarRental.Business.Logics
{
    internal class UserLogics
    {
        public static IResult CheckIfEmailAlreadyExist(IUserDal userDal, string email)
        {
            var result = userDal.Get(u => u.Email == email);

            return result == null ? new SuccessResult() : new ErrorResult(Messages.AlreadyExist("user"));
        }
    }
}
