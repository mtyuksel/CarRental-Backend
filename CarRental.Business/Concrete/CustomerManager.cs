using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this._customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public async Task<IResult> Add(Customer customer)
        {
            await _customerDal.Add(customer);

            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public async Task<IResult> Delete(Customer customer)
        {
            await _customerDal.Delete(customer);

            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAll());
        }

        public async Task<IDataResult<Customer>> GetByID(int userID)
        {
            return new SuccessDataResult<Customer>(await _customerDal.Get(c => c.UserID == userID));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public async Task<IResult> Update(Customer customer)
        {
            await _customerDal.Update(customer);

            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
