using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this._colorDal = colorDal;
        }

        public bool Add(Color entity)
        {
            _colorDal.Add(entity);

            return true;
        }

        public bool DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Color GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
