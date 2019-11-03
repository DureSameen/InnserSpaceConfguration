using System.Collections.Generic;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.SubscriptionConfigurations
{
    public class SubscriptionConfigurationsListQuery : IRequest<List<SubcriptionConfigurationReadModel>>
    {
        //
    }
}
