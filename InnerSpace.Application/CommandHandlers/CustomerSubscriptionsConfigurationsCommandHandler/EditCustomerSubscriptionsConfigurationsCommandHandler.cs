using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.ConfigurationCommandHandler
{
    public class EditCustomerSubscriptionsConfigurationsCommandHandler : IRequestHandler<EditCustomerSubscriptionsConfigurationsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerSubscriptionsConfigurationsRepository _configurationRepository;
        public EditCustomerSubscriptionsConfigurationsCommandHandler(IUnitOfWork unitOfWork, 
            ICustomerSubscriptionsConfigurationsRepository configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }

        public Task<Guid> Handle(EditCustomerSubscriptionsConfigurationsCommand request, CancellationToken cancellationToken)
        {
             CustomerSubscriptionsConfigurations configuration = _configurationRepository.Find(request.Id);

            if (configuration == null)
            {
                throw new Exception(typeof(CustomerSubscriptionsConfigurations).Name + " not found.");
            }

            configuration.Edit(request.UserSubscriptionId, request.ConfigurationId, request.Enabled);
            _unitOfWork.Save();

            return Task.FromResult(configuration.Id);
        }
    }
}
