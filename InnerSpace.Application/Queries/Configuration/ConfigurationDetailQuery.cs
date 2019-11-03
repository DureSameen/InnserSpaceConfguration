using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.Configuration
{
    public class ConfigurationDetailQuery : IRequest<ConfigurationReadModel>
    {
        public Guid Id { get; set; }
    }
}
