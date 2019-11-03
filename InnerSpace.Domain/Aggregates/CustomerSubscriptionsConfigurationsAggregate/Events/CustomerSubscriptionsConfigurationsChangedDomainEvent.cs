using System;
using InnerSpace.Shared.DomainInfrastructure;
using Newtonsoft.Json;

namespace InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate.Events
{
    public class CustomerSubscriptionsConfigurationsChangedDomainEvent : DomainEvent
    {
        public Guid UserSubscriptionId { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool Enabled { get; set; }

        public CustomerSubscriptionsConfigurationsChangedDomainEvent(Guid id, Guid userSubscriptionId, Guid configurationId, bool enabled)
        {
            Id = id;
            UserSubscriptionId = userSubscriptionId;
            ConfigurationId = configurationId;
            Enabled = enabled;
            
        }

        [JsonConstructor]
        public CustomerSubscriptionsConfigurationsChangedDomainEvent(Guid id,
            Guid userSubscriptionId,
            Guid configurationId,
            bool enabled,
            DateTimeOffset createdOn,
            DateTimeOffset lastChangedOn)
        {
            Id = id;
            UserSubscriptionId = userSubscriptionId;
            ConfigurationId = configurationId;
            Enabled = enabled;
            CreatedOn = createdOn;
            LastChangedOn = lastChangedOn;
            
        }
    }
}
