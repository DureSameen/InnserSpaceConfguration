using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
 
namespace InnerSpace.Infrastructure.Repositories
{
    public class UserSubscriptionsRepository : BaseRepository<UserSubscriptions>, IUserSubscriptionsRepository
    { 
        public UserSubscriptionsRepository(AppDataContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}
