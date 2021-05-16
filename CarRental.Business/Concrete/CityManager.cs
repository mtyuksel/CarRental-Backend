using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityService _cityDal;

        public CityManager(ICityService cityDal)
        {
            this._cityDal = cityDal;
        }

        public IResult Add(City entity)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(City entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<City>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<City> GetByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(City entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
