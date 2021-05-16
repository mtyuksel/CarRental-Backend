using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<CarRentalContext, Car>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandID equals b.ID
                             join clr in context.Colors on c.ColorID equals clr.ID
                             join l in context.Locations on c.LocationID equals l.ID
                             join cty in context.Cities on l.CityID equals cty.ID
                             select new CarDetailDTO
                             {
                                 CarID = c.ID,
                                 CarName = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandID = b.ID,
                                 BrandName = b.Name,
                                 ColorID = clr.ID,
                                 ColorName = clr.Name,
                                 CityID = cty.ID,
                                 CityName = cty.Name,
                                 LocationID = l.ID,
                                 LocationName = l.Name
                             };

                return result.ToList();
            }
        }
    }
}
