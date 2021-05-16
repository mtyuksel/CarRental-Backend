using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfLocationDal : EfEntityRepositoryBase<CarRentalContext, Location>, ILocationDal
    {
    }
}
