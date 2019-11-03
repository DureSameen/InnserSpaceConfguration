using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands
{
    public class CreateConfigurationCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
