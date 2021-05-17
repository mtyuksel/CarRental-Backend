using CarRental.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IServiceBase<T>
    {
        Task<IDataResult<List<T>>> GetAll();
        Task<IDataResult<T>> GetByID(int ID);
        Task<IResult> Add(T entity);
        Task<IResult> Update(T entity);
        Task<IResult> Delete(T entity);
    }
}
