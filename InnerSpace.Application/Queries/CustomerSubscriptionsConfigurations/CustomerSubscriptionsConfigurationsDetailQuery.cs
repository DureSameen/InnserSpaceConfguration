using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.CustomerSubscriptionsConfigurations
{
    public class CustomerSubscriptionsConfigurationsDetailQuery : IRequest<CustomerSubscriptionsConfigurationsReadModel>
    {
        public Guid Id { get; set; }
    }
}
