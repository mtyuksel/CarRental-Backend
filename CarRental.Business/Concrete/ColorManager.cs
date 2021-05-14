using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this._colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(ColorLogics.CheckIfColorAlreadyExist(_colorDal, color));

            if (!result.Success)
            {
                return result;
            }

            _colorDal.Add(color);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetByID(int ID)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ID == ID));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(ColorLogics.CheckIfColorAlreadyExist(_colorDal, color));

            if (!result.Success)
            {
                return result;
            }

            _colorDal.Update(color);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
