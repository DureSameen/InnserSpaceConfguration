
using System;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.CustomerSubscriptionsConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class CustomerSubscriptionsConfigurationsFactory: BaseFactory
    { 
        public static async Task<Guid> Create(Guid configurationId, Guid userSubscriptionId, bool enabled)
        {
            CreateCustomerSubscriptionsConfigurationsCommand command3 = new CreateCustomerSubscriptionsConfigurationsCommand { ConfigurationId = configurationId, UserSubscriptionId = userSubscriptionId, Enabled = enabled };
            Guid id = await Mediator.Send(command3); 
            return id;
        }

        public static async Task<CustomerSubscriptionsConfigurationsReadModel> GetById(Guid id)
        {
            CustomerSubscriptionsConfigurationsDetailQuery detailQuery = new CustomerSubscriptionsConfigurationsDetailQuery { Id = id };
            CustomerSubscriptionsConfigurationsReadModel configuration = await Mediator.Send(detailQuery);

            return configuration;
        }
    }
}
