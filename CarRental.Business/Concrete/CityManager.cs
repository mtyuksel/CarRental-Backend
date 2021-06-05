using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            this._cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            _cityDal.Add(city);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }

        public IDataResult<City> GetByID(int ID)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.ID == ID));
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
