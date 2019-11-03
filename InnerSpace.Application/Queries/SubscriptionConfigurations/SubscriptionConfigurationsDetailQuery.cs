using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.SubscriptionConfigurations
{
    public class SubscriptionConfigurationsDetailQuery : IRequest<SubcriptionConfigurationReadModel>
    {
        public Guid Id { get; set; }
    }
}
