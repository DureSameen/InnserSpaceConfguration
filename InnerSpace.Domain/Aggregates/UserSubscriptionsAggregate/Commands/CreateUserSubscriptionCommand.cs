using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class CreateUserSubscriptionCommand : IRequest<Guid>
    {
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public string APIKey { get; set; }
    }
}
