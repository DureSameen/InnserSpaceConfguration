using System.Collections.Generic;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.Configuration
{
    public class CustomerSubscriptionsConfigurationsListQuery : IRequest<List<CustomerSubscriptionsConfigurationsReadModel>>
    {
        //
    }
}
