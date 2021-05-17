using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            this._locationDal = locationDal;
        }

        public async Task<IResult> Add(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResult> Delete(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IDataResult<List<Location>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IDataResult<Location>> GetByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResult> Update(Location entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
