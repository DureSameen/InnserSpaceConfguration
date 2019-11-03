using System;
using MediatR;

namespace InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands
{
    public class CreateSubscriptionCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
