using System;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class ConfigurationFactory: BaseFactory
    {
         
        public static async Task<Guid> Create(string name, bool enabled)
        { 
            CreateConfigurationCommand command = new CreateConfigurationCommand { Name = name, Enabled = enabled };
            Guid Id = await Mediator.Send(command);

            return Id;
        }

        public static async Task<ConfigurationReadModel> GetById(Guid id)
        {
            ConfigurationDetailQuery detailQuery = new ConfigurationDetailQuery { Id = id };
            ConfigurationReadModel configuration = await Mediator.Send(detailQuery);

            return configuration;
        }
    }
}
