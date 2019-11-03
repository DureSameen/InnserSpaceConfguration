using System.Collections.Generic;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.UserSubscriptions
{
    public class UserSubscriptionsListQuery : IRequest<List<UserSubcriptionReadModel>>
    {
        //
    }
}
