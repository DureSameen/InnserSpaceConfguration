using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Subscription;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.SubscriptionCommandHandler
{
    public class SubscriptionDetailQueryHandler : IRequestHandler<SubscriptionDetailQuery, SubscriptionReadModel>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionDetailQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<SubscriptionReadModel> Handle(SubscriptionDetailQuery request, CancellationToken cancellationToken)
        {
            Subscription subscription = _subscriptionRepository.Find(request.Id);
            SubscriptionReadModel subscriptionReadModel = null;

            if (subscription != null)
            {
                subscriptionReadModel = new SubscriptionReadModel
                {
                    Id = subscription.Id,
                    Name = subscription.Name
                };
            }

            return Task.FromResult(subscriptionReadModel);
        }
    }
}
