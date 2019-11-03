using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;

namespace InnerSpace.Infrastructure.Repositories.Abstraction
{
    public interface IConfigurationRepository : IRepository<Configuration>
    {
        //
    }
}
