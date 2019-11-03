using System.Collections.Generic;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.Configuration
{
    public class ConfigurationsListQuery : IRequest<List<ConfigurationReadModel>>
    {
        //
    }
}
