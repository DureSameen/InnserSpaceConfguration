using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.SubscriptionCommandHandler
{
    public class EditUserSubscriptionCommandHandler : IRequestHandler<EditUserSubscriptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubscriptionsRepository _subscriptionRepository;

        public EditUserSubscriptionCommandHandler(IUnitOfWork unitOfWork, IUserSubscriptionsRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<Guid> Handle(EditUserSubscriptionCommand request, CancellationToken cancellationToken)
        {
            UserSubscriptions subscription = _subscriptionRepository.Find(request.Id);

            if (subscription == null)
            {
                throw new Exception(typeof(UserSubscriptions).Name + " not found.");
            }

            subscription.Edit(request.SubcriptionId, request.UserId,request.APIKey);
            _unitOfWork.Save();

            return Task.FromResult(subscription.Id);
        }
    }
}
