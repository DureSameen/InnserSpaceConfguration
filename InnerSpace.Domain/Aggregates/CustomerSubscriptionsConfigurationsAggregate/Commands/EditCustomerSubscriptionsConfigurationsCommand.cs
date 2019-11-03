using System;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class EditCustomerSubscriptionsConfigurationsCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserSubscriptionId { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool Enabled { get; set; }
    }
}
