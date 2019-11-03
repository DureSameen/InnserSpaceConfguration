using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InnerSpace.Domain;
using InnerSpace.Infrastructure.Logging;
using InnerSpace.Shared.DomainInfrastructure;
using InnerSpace.Shared.Serialization;

namespace InnerSpace.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _dbContext;

        public UnitOfWork(AppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            var modifiedEntries = _dbContext.ChangeTracker.Entries<IHasDomainEvents>().ToList();

            foreach (var entry in modifiedEntries)
            {
                IReadOnlyList<DomainEvent> domainEvents = entry.Entity.UncommittedChanges();

                if (domainEvents.Any())
                {
                    foreach (DomainEvent domainEvent in domainEvents)
                    {
                        string serializedEvent = Serializer.Serialize(domainEvent);

                        _dbContext.Set<EventLog>().Add(new EventLog(domainEvent.EventType, serializedEvent, domainEvent.AggregateRootId));
                    }

                    entry.Entity.MarkChangesAsCommitted();
                }
            }

            DateTraction(_dbContext);
            _dbContext.SaveChanges();
          

        }

        private void DateTraction(AppDataContext dbContext)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            var modifiedItems = dbContext.ChangeTracker
                .Entries<IModifiedOnTrackedEntity>()
                .Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified);

            var newItems = dbContext.ChangeTracker
                .Entries<ICreatedOnTrackedEntity>()
                .Where(entity => entity.State == EntityState.Added);

            foreach (var item in modifiedItems)
            {
                item.Entity.ModifiedOn = now;
            }

            foreach (var item in newItems)
            {
                item.Entity.CreatedOn = now;
            }
        }
    }
}
