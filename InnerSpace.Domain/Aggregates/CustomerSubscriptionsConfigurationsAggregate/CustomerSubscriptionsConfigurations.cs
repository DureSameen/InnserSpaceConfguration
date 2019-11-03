using System;
using System.Collections.Generic;
using System.Text;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate.Events;

namespace InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate
{
    public class CustomerSubscriptionsConfigurations : BaseEntity
    { 
        public Guid UserSubscriptionId { get; private set; }
        public Guid ConfigurationId { get; private set; }
        public bool Enabled { get; private set; }
        protected CustomerSubscriptionsConfigurations()
        {
            //
        }

        public static CustomerSubscriptionsConfigurations Create(Guid userSubscriptionId,Guid configurationId, bool enabled)
        {
            CustomerSubscriptionsConfigurations configuration = new CustomerSubscriptionsConfigurations 
            { 
                ConfigurationId= configurationId, 
                UserSubscriptionId= userSubscriptionId, 
                Enabled = enabled ,
                Id= Guid.NewGuid()
            };

            configuration.Raise(new CustomerSubscriptionsConfigurationsCreatedDomainEvent(configuration.Id, 
                configuration.UserSubscriptionId, 
                configuration.ConfigurationId, 
                configuration.Enabled));

            return configuration;
        }

        public void Edit(Guid uerSubscriptionId, Guid configurationId, bool enabled)
        {
            ConfigurationId = configurationId;
            UserSubscriptionId = uerSubscriptionId;
            Enabled = enabled;

            Raise(new CustomerSubscriptionsConfigurationsChangedDomainEvent(Id, UserSubscriptionId, ConfigurationId, Enabled));
        }
    }
}

