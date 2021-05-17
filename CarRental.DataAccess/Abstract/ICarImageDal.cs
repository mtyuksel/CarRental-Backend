using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        Task<List<string>> GetImagePathsByCarID(int carID);
    }
}
