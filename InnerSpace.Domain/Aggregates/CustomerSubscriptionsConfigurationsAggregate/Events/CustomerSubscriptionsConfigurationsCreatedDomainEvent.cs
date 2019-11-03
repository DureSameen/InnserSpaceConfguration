using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using InnerSpace.Shared.DomainInfrastructure;

namespace InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate.Events
{
    public class CustomerSubscriptionsConfigurationsCreatedDomainEvent : DomainEvent
    {
        public Guid UserSubscriptionId { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool Enabled { get; set; }

        public CustomerSubscriptionsConfigurationsCreatedDomainEvent(Guid id, Guid userSubscriptionId, Guid configurationId, bool enabled)
        {
            Id = id;
            UserSubscriptionId = userSubscriptionId;
            ConfigurationId = configurationId;
            Enabled = enabled;
        }

        [JsonConstructor]
        public CustomerSubscriptionsConfigurationsCreatedDomainEvent(Guid id,
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
