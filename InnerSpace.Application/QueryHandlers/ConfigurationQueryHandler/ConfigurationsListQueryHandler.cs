using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.ConfigurationQueryHandler
{
    public class ConfigurationsListQueryHandler : IRequestHandler<ConfigurationsListQuery, List<ConfigurationReadModel>>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationsListQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<List<ConfigurationReadModel>> Handle(ConfigurationsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Configuration> configurations = _configurationRepository.Query();
            List<ConfigurationReadModel> configurationsListReadModel = null;

            if (configurations != null && configurations.Any())
            {
                configurationsListReadModel = configurations.Select(x => new ConfigurationReadModel { Id = x.Id, Name = x.Name, Enabled= x.Enabled }).ToList();
            }

            return Task.FromResult(configurationsListReadModel);
        }
    }
}
