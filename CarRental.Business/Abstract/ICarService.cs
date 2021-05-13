using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        List<CarDetailDTO> GetCarDetails();
    }
}
