using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        Task<IDataResult<List<CarDetailDTO>>> GetCarDetails();
        Task<IResult> CheckIfCarExists(int ID);
    }
}
