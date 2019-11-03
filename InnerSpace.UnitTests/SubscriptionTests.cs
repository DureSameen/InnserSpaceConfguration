using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;

namespace InnerSpace.UnitTests
{
    public class SubscriptionTests
    {
         
        [Test]
        public void SubscriptionCreatedSuccessfully()
        {
            var _subscriptionRepository = StartUpTests.ServiceProvider.GetService<ISubscriptionRepository>();

            string subscriptionName = "A Subscription Name";

            Subscription subscription = Subscription.Create(subscriptionName, false);
            _subscriptionRepository.Save(subscription);
            StartUpTests.UnitOfWork.Save();
            Assert.IsNotNull(subscription.Id);

            Subscription subscriptionRead = _subscriptionRepository.Find(subscription.Id);

            Assert.IsNotNull(subscriptionRead);
            Assert.AreEqual(subscriptionName, subscriptionRead.Name);
            Assert.AreEqual(false, subscriptionRead.Enabled);
        }

        
    }
}