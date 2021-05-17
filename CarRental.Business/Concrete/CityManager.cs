using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityService _cityDal;

        public CityManager(ICityService cityDal)
        {
            this._cityDal = cityDal;
        }

        public async Task<IResult> Add(City entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResult> Delete(City entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IDataResult<List<City>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IDataResult<City>> GetByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResult> Update(City entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
