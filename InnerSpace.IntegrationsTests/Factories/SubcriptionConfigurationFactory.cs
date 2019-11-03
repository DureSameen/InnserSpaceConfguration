using System;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class SubcriptionConfigurationFactory : BaseFactory
    {
        
        public static async Task<Guid> Create(Guid subcriptionId, Guid configurationId, bool enabled)
        {
            CreateSubcriptionConfigurationCommand command = new CreateSubcriptionConfigurationCommand {  SubcriptionId= subcriptionId, ConfigurationId = configurationId , Enabled = enabled };
            Guid Id = await Mediator.Send(command);

            return Id;
        }

        public static async Task<SubcriptionConfigurationReadModel> GetById(Guid id)
        {
            SubscriptionConfigurationsDetailQuery detailQuery = new SubscriptionConfigurationsDetailQuery { Id = id };
            SubcriptionConfigurationReadModel configuration = await Mediator.Send(detailQuery);

            return configuration;
        }
    }
}
