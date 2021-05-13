using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using CarRental.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        public bool Add(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);

                return true;
            }

            return false;
        }

        public bool DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Car GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorID(int colorID)
        {
            return _carDal.GetAll(c => c.ColorID == colorID);
        }

        public List<Car> GetCarsByBrandID(int brandID)
        {
            return _carDal.GetAll(c => c.BrandID == brandID);
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
