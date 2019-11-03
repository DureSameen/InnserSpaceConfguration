using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.ConfigurationQueryHandler
{
    public class ConfigurationDetailQueryHandler : IRequestHandler<ConfigurationDetailQuery,  ConfigurationReadModel>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationDetailQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<ConfigurationReadModel> Handle(ConfigurationDetailQuery request, CancellationToken cancellationToken)
        {
            Configuration configuration = _configurationRepository.Find(request.Id);
            ConfigurationReadModel configurationReadModel = null;

            if (configuration != null)
            {
                configurationReadModel = new ConfigurationReadModel
                {
                    Id = configuration.Id,
                    Name = configuration.Name
                };
            }

            return Task.FromResult(configurationReadModel);
        }
    }
}
