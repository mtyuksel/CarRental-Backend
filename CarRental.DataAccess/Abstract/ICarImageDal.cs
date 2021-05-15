using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<string> GetImagePathsByCarID(int carID);
    }
}
