using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.UserSubscriptions;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.UserSubscriptionQueryHandler
{
    public class UserSubscriptionsListQueryHandler : IRequestHandler<UserSubscriptionsListQuery, List<UserSubcriptionReadModel>>
    {
        private readonly IUserSubscriptionsRepository _subscriptionRepository;

        public UserSubscriptionsListQueryHandler(IUserSubscriptionsRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<List<UserSubcriptionReadModel>> Handle(UserSubscriptionsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<UserSubscriptions> subscriptions = _subscriptionRepository.Query();
            List<UserSubcriptionReadModel> subscriptionsListReadModel = null;

            if (subscriptions != null && subscriptions.Any())
            {
                subscriptionsListReadModel = subscriptions.Select(x => new UserSubcriptionReadModel { Id = x.Id,  UserId= x.UserId, SubcriptionId= x.SubcriptionId, APIKey=x.APIKey}).ToList();
            }

            return Task.FromResult(subscriptionsListReadModel);
        }
    }
}
