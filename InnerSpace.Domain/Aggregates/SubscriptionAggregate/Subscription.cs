using System;
using System.Collections.Generic;
using System.Text;

namespace InnerSpace.Domain.Aggregates.SubscriptionAggregate
{
    public class Subscription : BaseEntity
    {
        public string Name { get; private set; }
        public bool Enabled { get; private set; }
        protected Subscription()
        {
            //
        }

        public static Subscription Create(string name, bool enabled)
        {
            Subscription subscription = new Subscription { Name = name , Enabled= enabled };

            return subscription;
        }

        public void Edit(string name, bool enabled)
        {
            Name = name;
            Enabled = enabled;
        }
    }
}
