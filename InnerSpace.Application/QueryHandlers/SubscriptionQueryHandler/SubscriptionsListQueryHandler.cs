using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.Queries.Subscription;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.SubscriptionQueryHandler
{
    public class SubscriptionsListQueryHandler : IRequestHandler<SubscriptionsListQuery, List<SubscriptionReadModel>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionsListQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<List<SubscriptionReadModel>> Handle(SubscriptionsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Subscription> subscriptions = _subscriptionRepository.Query();
            List<SubscriptionReadModel> subscriptionsListReadModel = null;

            if (subscriptions != null && subscriptions.Any())
            {
                subscriptionsListReadModel = subscriptions.Select(x => new SubscriptionReadModel { Id = x.Id, Name = x.Name }).ToList();
            }

            return Task.FromResult(subscriptionsListReadModel);
        }
    }
}
