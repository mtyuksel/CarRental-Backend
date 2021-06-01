using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;


namespace CarRental.Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<List<CarDetailDTO>> GetDetailedCarsByLocation(int locationID);
        IResult CheckIfCarExists(int ID);
    }
}
