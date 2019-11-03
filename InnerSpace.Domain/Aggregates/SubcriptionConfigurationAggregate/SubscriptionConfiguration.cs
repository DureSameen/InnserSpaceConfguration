using System;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate
{
    public class SubscriptionConfiguration : BaseEntity
    {
        public Guid SubcriptionId { get; private set; }
        public Guid ConfigurationId { get; private set; }
        public bool Enabled { get; private set; }
        protected SubscriptionConfiguration()
        {
            //
        }

        public static SubscriptionConfiguration Create(Guid subcriptionId, Guid configurationId, bool enabled)
        {
            SubscriptionConfiguration subscriptionConfiguration = new SubscriptionConfiguration { SubcriptionId = subcriptionId,ConfigurationId= configurationId, Enabled = enabled };

            return subscriptionConfiguration;
        }

        public void Edit(Guid subcriptionId, Guid configurationId, bool enabled)
        {
            SubcriptionId = subcriptionId;
            ConfigurationId = configurationId;
            Enabled = enabled;
        }
    }
}
 
