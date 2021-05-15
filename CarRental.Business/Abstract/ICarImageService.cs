using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService : IServiceBase<CarImage>
    {
        IDataResult<CarImage> GetByImagePath(string imagePath);
        IDataResult<List<string>> GetAllImagePathsByCarID(int carID);
    }
}
