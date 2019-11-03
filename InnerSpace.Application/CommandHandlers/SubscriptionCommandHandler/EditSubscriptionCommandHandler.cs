using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.SubscriptionCommandHandler
{
    public class EditSubscriptionCommandHandler : IRequestHandler<EditSubscriptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public EditSubscriptionCommandHandler(IUnitOfWork unitOfWork, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<Guid> Handle(EditSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription subscription = _subscriptionRepository.Find(request.Id);

            if (subscription == null)
            {
                throw new Exception(typeof(Subscription).Name + " not found.");
            }

            subscription.Edit(request.Name, request.Enabled);
            _unitOfWork.Save();

            return Task.FromResult(subscription.Id);
        }
    }
}
