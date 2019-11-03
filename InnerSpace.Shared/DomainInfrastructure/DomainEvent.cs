using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InnerSpace.Shared.DomainInfrastructure
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; } = Guid.NewGuid(); 
        public Guid AggregateRootId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastChangedOn { get; set; }
        public DateTimeOffset OccuredOn { get; set; }
        public string EventType { get; set; }
    }
}
