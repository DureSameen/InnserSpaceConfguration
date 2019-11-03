using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InnerSpace.Domain;
using InnerSpace.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;

namespace InnerSpace.Infrastructure.Repositories.Logging
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly DbContext _dbContext;

        public EventLogRepository(AppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual EventLog Find(Guid id)
        {
            return _dbContext.Set<EventLog>().SingleOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<EventLog> Query(Expression<Func<EventLog, bool>> expression = null)
        {
            IQueryable<EventLog> baseQuery = _dbContext.Set<EventLog>();

            if (expression == null)
            {
                return baseQuery.AsQueryable();
            }

            return baseQuery.Where(expression).AsQueryable();
        }

        public void Save(EventLog entity)
        {
            _dbContext.Set<EventLog>().Add(entity);
        }
    }
}
