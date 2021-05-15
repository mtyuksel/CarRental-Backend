using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarImages : EfEntityRepositoryBase<CarRentalContext, CarImage>, ICarImageDal
    {
        public List<string> GetImagePathsByCarID(int carID)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                List<string> result = context.CarImages.Where(i => i.CarID == carID).Select(i => i.ImagePath).ToList();

                return result;
            }
        }
    }
}
