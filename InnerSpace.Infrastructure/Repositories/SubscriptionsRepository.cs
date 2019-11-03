using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;

namespace InnerSpace.Infrastructure.Repositories
{
    public class SubscriptionsRepository : BaseRepository<Subscription>, ISubscriptionRepository
    { 
        public SubscriptionsRepository(AppDataContext dbContext)
            : base(dbContext)
        { 

        }
    }
}
