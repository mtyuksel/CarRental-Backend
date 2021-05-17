using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    [SecuredOperation("color,admin")]
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this._colorDal = colorDal;
        }

        [SecuredOperation("color.add,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public async Task<IResult> Add(Color color)
        {
            var result = BusinessRules.Run(ColorLogics.CheckIfColorAlreadyExist(_colorDal, color));

            if (!result.Success)
            {
                return result;
            }

            await _colorDal.Add(color);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [SecuredOperation("color.delete,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IResult> Delete(Color color)
        {
            await _colorDal.Add(color);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public async Task<IDataResult<List<Color>>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(await _colorDal.GetAll());
        }

        public async Task<IDataResult<Color>> GetByID(int ID)
        {
            return new SuccessDataResult<Color>(await _colorDal.Get(c => c.ID == ID));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICarImageManager.Get")]
        public async Task<IResult> Update(Color color)
        {
            var result = BusinessRules.Run(ColorLogics.CheckIfColorAlreadyExist(_colorDal, color));

            if (!result.Success)
            {
                return result;
            }

            await _colorDal.Update(color);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
