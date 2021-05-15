using CarRental.Core.DataAccess.Abstract;
using CarRental.Core.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
