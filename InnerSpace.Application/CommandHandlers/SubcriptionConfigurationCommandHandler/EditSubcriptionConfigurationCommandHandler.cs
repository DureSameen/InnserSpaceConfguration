using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.ConfigurationCommandHandler
{
    public class EditSubcriptionConfigurationCommandHandler : IRequestHandler<EditSubcriptionConfigurationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionConfigurationRepository _configurationRepository;

        public EditSubcriptionConfigurationCommandHandler(IUnitOfWork unitOfWork, ISubscriptionConfigurationRepository configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }

        public Task<Guid> Handle(EditSubcriptionConfigurationCommand request, CancellationToken cancellationToken)
        {
            SubscriptionConfiguration configuration = _configurationRepository.Find(request.Id);

            if (configuration == null)
            {
                throw new Exception(typeof(SubscriptionConfiguration).Name + " not found.");
            }

            configuration.Edit(request.SubcriptionId,request.ConfigurationId, request.Enabled);
            _unitOfWork.Save();

            return Task.FromResult(configuration.Id);
        }
    }
}
