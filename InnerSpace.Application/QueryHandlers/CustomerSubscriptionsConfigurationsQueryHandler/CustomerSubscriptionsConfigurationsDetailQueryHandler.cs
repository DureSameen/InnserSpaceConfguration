using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.CustomerSubscriptionsConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.ConfigurationQueryHandler
{
    public class CustomerSubscriptionsConfigurationsDetailQueryHandler : IRequestHandler<CustomerSubscriptionsConfigurationsDetailQuery, CustomerSubscriptionsConfigurationsReadModel>
    {
        private readonly ICustomerSubscriptionsConfigurationsRepository _configurationRepository;

        public CustomerSubscriptionsConfigurationsDetailQueryHandler(ICustomerSubscriptionsConfigurationsRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<CustomerSubscriptionsConfigurationsReadModel> Handle(CustomerSubscriptionsConfigurationsDetailQuery request, CancellationToken cancellationToken)
        {
            CustomerSubscriptionsConfigurations configuration = _configurationRepository.Find(request.Id);
            CustomerSubscriptionsConfigurationsReadModel configurationReadModel = null;

            if (configuration != null)
            {
                configurationReadModel = new CustomerSubscriptionsConfigurationsReadModel
                {
                   Id = configuration.Id,
                   ConfigurationId= configuration.ConfigurationId,
                   Enabled= configuration.Enabled
                };
            }

            return Task.FromResult(configurationReadModel);
        }
    }
}
