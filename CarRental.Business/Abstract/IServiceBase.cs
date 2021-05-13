using CarRental.Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface IServiceBase<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetByID(int ID);
        IResult Add(T entity); 
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
