using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}
