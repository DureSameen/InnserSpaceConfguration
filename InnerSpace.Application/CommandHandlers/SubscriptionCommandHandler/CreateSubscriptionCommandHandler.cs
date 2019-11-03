using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateSubscriptionCommandHandler(IUnitOfWork unitOfWork, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<Guid> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription subscription = Subscription.Create(request.Name, request.Enabled);

            _subscriptionRepository.Save(subscription);
            _unitOfWork.Save();

            return Task.FromResult<Guid>(subscription.Id);
        }
    }
}
