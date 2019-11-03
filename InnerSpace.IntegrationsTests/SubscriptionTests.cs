using System;
using System.Threading.Tasks;
using InnerSpace.IntegrationsTests.Factories;
using NUnit.Framework;

namespace InnerSpace.IntegrationsTests
{

    public class SubscriptionTests
    {
        [Test]
        public async Task CreateSubscriptionSuccessfully()
        {
            string subscriptionName = "professional";
            var id = await SubcriptionFactory.Create(subscriptionName, true);
            Assert.AreNotEqual(id, Guid.Empty);

            var subscription = await SubcriptionFactory.GetById(id);
            Assert.AreEqual(subscriptionName, subscription.Name);
        }


    }
}