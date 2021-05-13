using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IServiceBase<T>
    {
        T GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool DeleteByID(int ID);
    }
}
