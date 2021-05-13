using CarRental.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace CarRental.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T enitity);
        void Update(T enitity);
        void Delete(T enitity);
    }
}
