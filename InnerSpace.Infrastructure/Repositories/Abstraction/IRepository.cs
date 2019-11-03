using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnerSpace.Infrastructure.Repositories.Abstraction
{
    public interface IRepository<T> where T : class
    {
        T Find(Guid id);
        IQueryable<T> Query(Expression<Func<T, bool>> expression = null);
        void Save(T entity);
    }
}
