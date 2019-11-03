using System;

namespace InnerSpace.Application.ReadModels
{
    public class CustomerSubscriptionsConfigurationsReadModel : BaseReadModel
    {
        public Guid UserSubscriptionId { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool Enabled { get; set; }
    }
}
