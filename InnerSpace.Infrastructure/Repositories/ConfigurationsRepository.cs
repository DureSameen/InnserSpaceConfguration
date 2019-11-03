using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;

namespace InnerSpace.Infrastructure.Repositories
{
    public class ConfigurationsRepository : BaseRepository<Configuration>, IConfigurationRepository
    {
       
        public ConfigurationsRepository(AppDataContext dbContext)
            : base(dbContext)
        { 

        }
    }
}
