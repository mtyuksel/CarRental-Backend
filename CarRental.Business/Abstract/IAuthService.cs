using CarRental.Core.Entity.Concrete;
using CarRental.Core.Utilities.Results;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entity.DTOs;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDTO userForRegisterDTO, string password);
        IDataResult<User> Login(UserForLoginDTO userForRegisterDTO);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
