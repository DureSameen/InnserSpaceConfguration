using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InnerSpace.Domain;
using Microsoft.EntityFrameworkCore;

namespace InnerSpace.Infrastructure.Repositories.Abstraction
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Find(Guid id)
        {
            return _dbContext.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> baseQuery = _dbContext.Set<T>();

            if (expression == null)
            {
                return baseQuery.AsQueryable();
            }

            return baseQuery.Where(expression).AsQueryable();
        }

        public void Save(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
    }
}
