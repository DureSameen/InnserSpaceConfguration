using System;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class EditSubcriptionConfigurationCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid SubcriptionId { get; private set; }
        public Guid ConfigurationId { get; private set; }
        public bool Enabled { get; set; }
    }
}
