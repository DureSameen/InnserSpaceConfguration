using System;
using System.Collections.Generic;
using System.Text;

namespace InnerSpace.Shared.DomainInfrastructure
{
    public interface IHasDomainEvents
    {
        IReadOnlyList<DomainEvent> UncommittedChanges();
        void MarkChangesAsCommitted();
        void Raise(DomainEvent @event);
    }
}
