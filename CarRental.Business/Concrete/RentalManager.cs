using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this._rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
