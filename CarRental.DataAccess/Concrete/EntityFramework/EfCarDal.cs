using CarRental.Core.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<CarRentalContext, Car>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails(string uploadPath, string defaultImageFullPath)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Set<Car>()
                             join b in context.Set<Brand>() on c.BrandID equals b.ID
                             join clr in context.Set<Color>() on c.ColorID equals clr.ID
                             join l in context.Set<Location>() on c.LocationID equals l.ID
                             join cty in context.Set<City>() on l.CityID equals cty.ID
                             select new CarDetailDTO
                             {
                                 ID = c.ID,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 Brand = b,
                                 Color = clr,
                                 Location = new LocationDTO { ID = l.ID, Name = l.Name, City = cty },
                                 Images = (context.CarImages.Any(i => i.CarID == c.ID))
                                     ? context.CarImages.Where(i => i.CarID == c.ID).Select(i => new CarImage { ID = i.ID, CarID = i.CarID, Date = i.Date, ImagePath = uploadPath + i.ImagePath }).ToList()
                                     : new List<CarImage>() { new CarImage { ID = 0, CarID = c.ID, Date = DateTime.Now, ImagePath = defaultImageFullPath } }
                             };
                
                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetDetailedCarsByLocation(int locationID, string uploadPath, string defaultImageFullPath)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                 var result = from c in context.Set<Car>()
                             join b in context.Set<Brand>() on c.BrandID equals b.ID
                             join clr in context.Set<Color>() on c.ColorID equals clr.ID
                             join l in context.Set<Location>() on c.LocationID equals l.ID
                             join cty in context.Set<City>() on l.CityID equals cty.ID
                             where c.LocationID == locationID 
                             && (!(from r in context.Rentals where r.CarID == c.ID && r.ReturnDate == null select r.ID).Any() || !(from r in context.Rentals where r.CarID == c.ID select r.ID).Any())
                             select new CarDetailDTO
                             {
                                 ID = c.ID,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 Brand = b,
                                 Color = clr,
                                 Location = new LocationDTO { ID = l.ID, Name = l.Name, City = cty },
                                 Images = (context.CarImages.Any(i => i.CarID == c.ID))
                                     ? context.CarImages.Where(i => i.CarID == c.ID).Select(i => new CarImage { ID = i.ID, CarID = i.CarID, Date = i.Date, ImagePath = uploadPath + i.ImagePath }).ToList()
                                     : new List<CarImage>() { new CarImage { ID = 0, CarID = c.ID, Date = DateTime.Now, ImagePath = defaultImageFullPath } }
                             };

                return result.ToList();
            }
        }
    }
}
