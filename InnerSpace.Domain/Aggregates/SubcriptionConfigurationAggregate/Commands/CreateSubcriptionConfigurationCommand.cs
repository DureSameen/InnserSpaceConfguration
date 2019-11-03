using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class CreateSubcriptionConfigurationCommand : IRequest<Guid>
    {
        public Guid SubcriptionId { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool Enabled { get; set; }
    }
}
