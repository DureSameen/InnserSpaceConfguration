using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.SubscriptionConfigurations
{
    public class UserSubscriptionDetailQuery : IRequest<UserSubcriptionReadModel>
    {
        public Guid Id { get; set; }
    }
}
