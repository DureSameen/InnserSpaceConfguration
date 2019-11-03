using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.ConfigurationQueryHandler
{
    public class CreateSubcriptionConfigurationCommandHandler : IRequestHandler<CreateSubcriptionConfigurationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionConfigurationRepository _configurationRepository;

        public CreateSubcriptionConfigurationCommandHandler(IUnitOfWork unitOfWork, ISubscriptionConfigurationRepository configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }

        public Task<Guid> Handle(CreateSubcriptionConfigurationCommand request, CancellationToken cancellationToken)
        {
            SubscriptionConfiguration configuration = SubscriptionConfiguration.Create(request.SubcriptionId,request.ConfigurationId, request.Enabled);

            _configurationRepository.Save(configuration);
            _unitOfWork.Save();

            return Task.FromResult(configuration.Id);
        }
    }
}
