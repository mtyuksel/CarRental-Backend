using CarRental.Core.Entity.Concrete;
using CarRental.Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface IUserService : IServiceBase<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
