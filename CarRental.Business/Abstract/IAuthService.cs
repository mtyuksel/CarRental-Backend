using CarRental.Core.Entity.Concrete;
using CarRental.Core.Utilities.Results;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entity.DTOs;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserForRegisterDTO userForRegisterDTO, string password);
        Task<IDataResult<User>> Login(UserForLoginDTO userForRegisterDTO);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
