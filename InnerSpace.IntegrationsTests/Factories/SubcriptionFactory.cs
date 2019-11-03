using System;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Subscription;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class SubcriptionFactory : BaseFactory
    {
         
        public static async Task<Guid> Create(string name, bool enabled)
        {
            CreateSubscriptionCommand command = new CreateSubscriptionCommand { Name = name, Enabled = enabled };
            Guid Id = await Mediator.Send(command);

            return Id;
        }

        public static async Task<SubscriptionReadModel> GetById(Guid id)
        {
            SubscriptionDetailQuery detailQuery = new SubscriptionDetailQuery { Id = id };
            SubscriptionReadModel configuration = await Mediator.Send(detailQuery);

            return configuration;
        }
    }
}
