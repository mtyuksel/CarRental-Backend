using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            this._locationDal = locationDal;
        }

        public IResult Add(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Location>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Location> GetByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Location entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
