using System;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using MediatR;

namespace InnerSpace.Application.CommandHandlers.ConfigurationCommandHandler
{
    public class CreateConfigurationCommandHandler : IRequestHandler<CreateConfigurationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigurationRepository _configurationRepository;

        public CreateConfigurationCommandHandler(IUnitOfWork unitOfWork, IConfigurationRepository configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }

        public Task<Guid> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
        {
            Configuration configuration = Configuration.Create(request.Name, request.Enabled);

            _configurationRepository.Save(configuration);
            _unitOfWork.Save();

            return Task.FromResult(configuration.Id);
        }
    }
}
