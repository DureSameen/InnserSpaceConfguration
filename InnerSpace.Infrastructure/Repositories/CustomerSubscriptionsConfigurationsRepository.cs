using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;

namespace InnerSpace.Infrastructure.Repositories
{
    public class CustomerSubscriptionsConfigurationsRepository : BaseRepository<CustomerSubscriptionsConfigurations>, ICustomerSubscriptionsConfigurationsRepository
    { 
        public CustomerSubscriptionsConfigurationsRepository(AppDataContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}

