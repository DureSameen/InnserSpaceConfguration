using System;
using MediatR;

namespace InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands
{
    public class EditSubscriptionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
