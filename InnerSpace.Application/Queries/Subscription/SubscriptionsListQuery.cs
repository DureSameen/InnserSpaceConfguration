using System;
using System.Collections.Generic;
using System.Text;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.Subscription
{
    public class SubscriptionsListQuery : IRequest<List<SubscriptionReadModel>>
    {
        //
    }
}
