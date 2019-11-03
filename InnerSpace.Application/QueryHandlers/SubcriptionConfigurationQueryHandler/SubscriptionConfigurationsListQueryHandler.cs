using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.SubcriptionConfigurationQueryHandler
{
    public class SubscriptionConfigurationsListQueryHandler : IRequestHandler<SubscriptionConfigurationsListQuery, List<SubcriptionConfigurationReadModel>>
    {
        private readonly ISubscriptionConfigurationRepository _configurationRepository;

        public SubscriptionConfigurationsListQueryHandler(ISubscriptionConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<List<SubcriptionConfigurationReadModel>> Handle(SubscriptionConfigurationsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<SubscriptionConfiguration> configurations = _configurationRepository.Query();
            List<SubcriptionConfigurationReadModel> configurationsListReadModel = null;

            if (configurations != null && configurations.Any())
            {
                configurationsListReadModel = configurations.Select(x => new SubcriptionConfigurationReadModel { Id = x.Id, SubcriptionId = x.SubcriptionId, ConfigurationId = x.ConfigurationId, Enabled = x.Enabled }).ToList();
            }

            return Task.FromResult(configurationsListReadModel);
        }
    }
}
