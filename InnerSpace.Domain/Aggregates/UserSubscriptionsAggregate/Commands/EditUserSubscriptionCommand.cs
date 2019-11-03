using System;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class EditUserSubscriptionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid SubcriptionId { get; set; }
        public Guid UserId { get; set; }
        public string APIKey { get; set; }
    }
}
