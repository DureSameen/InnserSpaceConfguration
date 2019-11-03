using System;

namespace InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate
{
    public class UserSubscriptions : BaseEntity
    {
        public Guid SubcriptionId { get; private set; }
        public Guid UserId { get; private set; }
        public string APIKey { get; private set; }
        protected UserSubscriptions()
        {
            //
        }

        public static UserSubscriptions Create(Guid subcriptionId, Guid userId, string aPIKey)
        {
            UserSubscriptions subscriptionConfiguration = new UserSubscriptions { SubcriptionId = subcriptionId, UserId = userId, APIKey = aPIKey };

            return subscriptionConfiguration;
        }

        public void Edit(Guid subcriptionId, Guid userId, string aPIKey)
        {
            SubcriptionId = subcriptionId;
            UserId = userId;
            APIKey = aPIKey;

        }
    }
}

