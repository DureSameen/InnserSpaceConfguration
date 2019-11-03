using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;

namespace InnerSpace.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateUserSubscriptionCommandHandler : IRequestHandler<CreateUserSubscriptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubscriptionsRepository _subscriptionRepository;

        public CreateUserSubscriptionCommandHandler(IUnitOfWork unitOfWork, IUserSubscriptionsRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<Guid> Handle(CreateUserSubscriptionCommand request, CancellationToken cancellationToken)
        {
            UserSubscriptions subscription = UserSubscriptions.Create(request.SubscriptionId,request.UserId, request.APIKey);

            _subscriptionRepository.Save(subscription);
            _unitOfWork.Save();

            return Task.FromResult<Guid>(subscription.Id);
        }
    }
}
