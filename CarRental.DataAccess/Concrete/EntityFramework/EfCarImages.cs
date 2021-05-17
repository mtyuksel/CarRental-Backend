using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarImages : EfEntityRepositoryBase<CarRentalContext, CarImage>, ICarImageDal
    {
        public async Task<List<string>> GetImagePathsByCarID(int carID)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                List<string> result = await context.CarImages.Where(i => i.CarID == carID).Select(i => i.ImagePath).ToListAsync();

                return result;
            }
        }
    }
}
