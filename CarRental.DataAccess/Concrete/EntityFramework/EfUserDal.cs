using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.Core.Entity.Concrete;
using CarRental.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<CarRentalContext, User>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
