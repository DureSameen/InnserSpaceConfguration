using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;
using Newtonsoft.Json;

namespace InnerSpace.Application.QueryHandlers.ConfigurationQueryHandler
{
    public class CreateCustomerSubscriptionsConfigurationsCommandHandler : IRequestHandler<CreateCustomerSubscriptionsConfigurationsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerSubscriptionsConfigurationsRepository _customerSubscriptionsConfigurationsRepository;
        public CreateCustomerSubscriptionsConfigurationsCommandHandler(IUnitOfWork unitOfWork, 
            ICustomerSubscriptionsConfigurationsRepository customerSubscriptionsConfigurationsRepository)
        {
            _unitOfWork = unitOfWork;
            _customerSubscriptionsConfigurationsRepository = customerSubscriptionsConfigurationsRepository;
        }

        public Task<Guid> Handle(CreateCustomerSubscriptionsConfigurationsCommand request, CancellationToken cancellationToken)
        {
            CustomerSubscriptionsConfigurations customerSubscriptionsConfigurations = CustomerSubscriptionsConfigurations.Create(request.UserSubscriptionId,request.ConfigurationId,  request.Enabled);

            _customerSubscriptionsConfigurationsRepository.Save(customerSubscriptionsConfigurations);
            _unitOfWork.Save();

            return Task.FromResult(customerSubscriptionsConfigurations.Id);
        }
    }
}
