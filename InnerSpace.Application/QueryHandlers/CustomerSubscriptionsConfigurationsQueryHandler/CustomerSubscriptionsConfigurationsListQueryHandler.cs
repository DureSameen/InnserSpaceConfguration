using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.Queries.CustomerSubscriptionsConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.CustomerSubscriptionsConfigurationsQueryHandler
{
    public class CustomerSubscriptionsConfigurationsListQueryHandler : IRequestHandler<CustomerSubscriptionsConfigurationsListQuery, List<CustomerSubscriptionsConfigurationsReadModel>>
    {
        private readonly ICustomerSubscriptionsConfigurationsRepository _configurationRepository;

        public CustomerSubscriptionsConfigurationsListQueryHandler(ICustomerSubscriptionsConfigurationsRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<List<CustomerSubscriptionsConfigurationsReadModel>> Handle(CustomerSubscriptionsConfigurationsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CustomerSubscriptionsConfigurations> configurations = _configurationRepository.Query();
            List<CustomerSubscriptionsConfigurationsReadModel> configurationsListReadModel = null;

            if (configurations != null && configurations.Any())
            {
                configurationsListReadModel = configurations.Select(x => new CustomerSubscriptionsConfigurationsReadModel { Id = x.Id,  ConfigurationId= x.ConfigurationId, UserSubscriptionId= x.UserSubscriptionId, Enabled= x.Enabled }).ToList();
            }

            return Task.FromResult(configurationsListReadModel);
        }
    }
}
