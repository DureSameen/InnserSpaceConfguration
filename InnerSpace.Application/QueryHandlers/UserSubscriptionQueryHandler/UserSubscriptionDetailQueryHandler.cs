using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Subscription;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure.Repositories;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.UserSubscriptionQueryHandler
{
    public class UserSubscriptionDetailQueryHandler : IRequestHandler<UserSubscriptionDetailQuery, UserSubcriptionReadModel>
    {
        private readonly IUserSubscriptionsRepository _subscriptionRepository;

        public UserSubscriptionDetailQueryHandler(IUserSubscriptionsRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<UserSubcriptionReadModel> Handle(UserSubscriptionDetailQuery request, CancellationToken cancellationToken)
        {
            UserSubscriptions subscription = _subscriptionRepository.Find(request.Id);
            UserSubcriptionReadModel subscriptionReadModel = null;

            if (subscription != null)
            {
                subscriptionReadModel = new UserSubcriptionReadModel
                {
                    Id = subscription.Id,
                    APIKey= subscription.APIKey,
                    SubcriptionId= subscription.SubcriptionId,
                    UserId= subscription.UserId
                };
            }

            return Task.FromResult(subscriptionReadModel);
        }
    }
}
