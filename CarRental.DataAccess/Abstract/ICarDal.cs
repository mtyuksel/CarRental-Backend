using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System;
using System.Collections.Generic;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails();
        List<CarDetailDTO> GetDetailedCarsByLocation(int locationID);

    }
}
