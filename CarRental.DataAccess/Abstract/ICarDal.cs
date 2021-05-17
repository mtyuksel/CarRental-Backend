using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        Task<List<CarDetailDTO>> GetCarDetails();
    }
}
