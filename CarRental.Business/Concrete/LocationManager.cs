using CarRental.Business.Abstract;
using CarRental.Business.Constants;
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

        public IResult Add(Location location)
        {
            _locationDal.Add(location);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Location>> GetAll()
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetAll());
        }

        public IDataResult<Location> GetByID(int ID)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(loc => loc.ID == ID));
        }

        public IResult Update(Location location)
        {
            _locationDal.Update(location);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
