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
    public class EditConfigurationCommandHandler : IRequestHandler<EditConfigurationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigurationRepository _configurationRepository;

        public EditConfigurationCommandHandler(IUnitOfWork unitOfWork, IConfigurationRepository configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }

        public Task<Guid> Handle(EditConfigurationCommand request, CancellationToken cancellationToken)
        {
            Configuration configuration = _configurationRepository.Find(request.Id);

            if (configuration == null)
            {
                throw new Exception(typeof(Configuration).Name + " not found.");
            }

            configuration.Edit(request.Name, request.Enabled);
            _unitOfWork.Save();

            return Task.FromResult(configuration.Id);
        }
    }
}
