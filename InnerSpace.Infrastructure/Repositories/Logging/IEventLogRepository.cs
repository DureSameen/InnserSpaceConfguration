using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InnerSpace.Infrastructure.Logging;

namespace InnerSpace.Infrastructure.Repositories.Logging
{
    public interface IEventLogRepository 
    {
        EventLog Find(Guid id);
        IQueryable<EventLog> Query(Expression<Func<EventLog, bool>> expression = null);
        void Save(EventLog entity);
    }
}
