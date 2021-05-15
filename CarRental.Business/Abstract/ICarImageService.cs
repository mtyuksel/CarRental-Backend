using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService : IServiceBase<CarImage>
    {
        IDataResult<CarImage> GetByImagePath(string imagePath);
    }
}
