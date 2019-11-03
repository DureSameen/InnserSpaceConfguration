
using System;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class UserSubscriptionFactory : BaseFactory
    {
         
        public static async Task<Guid> Create(string apiKey, Guid subscriptionId, Guid userId)
        {
            CreateUserSubscriptionCommand command1 = new CreateUserSubscriptionCommand { APIKey = apiKey,  SubscriptionId= subscriptionId,  UserId= userId };
            Guid id = await Mediator.Send(command1);
            return id;
        }
    }
}
