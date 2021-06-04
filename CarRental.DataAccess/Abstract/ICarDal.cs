using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails(string uploadPath, string defaultImageFullPath);
        List<CarDetailDTO> GetDetailedCarsByLocation(int locationID, string uploadPath, string defaultImageFullPath);

    }
}
