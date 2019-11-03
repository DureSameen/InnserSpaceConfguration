using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.SubcriptionConfigurationQueryHandler
{
    public class SubscriptionConfigurationDetailQueryHandler : IRequestHandler<SubscriptionConfigurationsDetailQuery, SubcriptionConfigurationReadModel>
    {
        private readonly ISubscriptionConfigurationRepository _subscriptionRepository;

        public SubscriptionConfigurationDetailQueryHandler(ISubscriptionConfigurationRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<SubcriptionConfigurationReadModel> Handle(SubscriptionConfigurationsDetailQuery request, CancellationToken cancellationToken)
        {
            SubscriptionConfiguration subscriptionConfiguration = _subscriptionRepository.Find(request.Id);
            SubcriptionConfigurationReadModel subscriptionReadModel = null;

            if (subscriptionConfiguration != null)
            {
                subscriptionReadModel = new SubcriptionConfigurationReadModel
                {
                    Id = subscriptionConfiguration.Id,
                    ConfigurationId = subscriptionConfiguration.ConfigurationId,
                    SubcriptionId = subscriptionConfiguration.SubcriptionId,
                    Enabled = subscriptionConfiguration.Enabled

                };

            }
            return Task.FromResult(subscriptionReadModel);

        }
    }
}