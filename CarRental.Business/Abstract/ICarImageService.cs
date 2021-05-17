using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService : IServiceBase<CarImage>
    {
        Task<IDataResult<CarImage>> GetByImagePath(string imagePath);
        Task<IDataResult<List<string>>> GetAllImagePathsByCarID(int carID);
    }
}
