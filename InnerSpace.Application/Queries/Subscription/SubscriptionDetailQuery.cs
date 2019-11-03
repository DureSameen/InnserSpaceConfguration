using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.Subscription
{
    public class SubscriptionDetailQuery : IRequest<SubscriptionReadModel>
    {
        public Guid Id { get; set; }
    }
}
