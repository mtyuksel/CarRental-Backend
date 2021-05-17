using CarRental.Core.Entity.Concrete;
using CarRental.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IDataResult<List<OperationClaim>>> GetClaims(User user);
        Task<IDataResult<User>> GetByMail(string email);
    }
}
