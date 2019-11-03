using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using InnerSpace.Shared.DomainInfrastructure;

namespace InnerSpace.Domain
{
    public abstract class BaseEntity : IBaseEntity, ICreatedOnTrackedEntity, IModifiedOnTrackedEntity, IHasDomainEvents
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        private IList<DomainEvent> Events { get; } = new List<DomainEvent>();

        public IReadOnlyList<DomainEvent> UncommittedChanges()
        {
            return new ReadOnlyCollection<DomainEvent>(Events);
        }

        public void MarkChangesAsCommitted()
        {
            Events.Clear();
        }

        void IHasDomainEvents.Raise(DomainEvent @event)
        {
            Events.Add(@event);
        }

        protected void Raise(DomainEvent @event)
        {
            @event.AggregateRootId = Id;
            @event.Id = Guid.NewGuid();
            @event.EventId = @event.EventId;
            @event.OccuredOn = DateTimeOffset.UtcNow;
            @event.EventType = @event.GetType().Name;
            @event.CreatedOn = DateTimeOffset.UtcNow;
            @event.LastChangedOn = DateTimeOffset.UtcNow;

            (this as IHasDomainEvents).Raise(@event);
        }
    }
}
