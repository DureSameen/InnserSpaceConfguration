using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InnerSpace.Shared.DomainInfrastructure
{
    public interface IDomainEvent : INotification
    {
    }
}
