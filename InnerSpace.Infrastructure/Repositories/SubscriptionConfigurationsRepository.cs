using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;

namespace InnerSpace.Infrastructure.Repositories
{
    public class SubcriptionConfigurationsRepository : BaseRepository<SubscriptionConfiguration>, ISubscriptionConfigurationRepository
    { 
        public SubcriptionConfigurationsRepository(AppDataContext dbContext)
            : base(dbContext)
        {
           
        }
    }
}
