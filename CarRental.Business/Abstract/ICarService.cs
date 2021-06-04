using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;


namespace CarRental.Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        IDataResult<List<CarDetailDTO>> GetCarDetails(string uploadPath, string defaultImageFullPath);
        IDataResult<List<CarDetailDTO>> GetDetailedCarsByLocation(int locationID, string uploadPath, string defaultImageFullPath);
        IResult CheckIfCarExists(int ID);
    }
}
