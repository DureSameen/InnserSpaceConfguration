using System;
using System.Threading.Tasks;
using InnerSpace.IntegrationsTests.Factories;
using NUnit.Framework;

namespace InnerSpace.IntegrationsTests
{

    public class UserSubscriptionsTests
    {
        [Test]
        public async Task CreateUserSubscriptionSuccessfully()
        {
            //create a subscription..standard1

            string subscriptionName = "Standard1";
            var subcriptionId = await SubcriptionFactory.Create(subscriptionName, true);
            Assert.AreNotEqual(subcriptionId, Guid.Empty);

            var subscription = await SubcriptionFactory.GetById(subcriptionId);
            Assert.AreEqual(subscriptionName, subscription.Name);

            //create a user subscription..with ApiKey

            var id = UserSubscriptionFactory.Create(ApiKeyHelper.CreateApiKey(), subcriptionId, Guid.NewGuid());
            Assert.AreNotEqual(id, Guid.Empty);


        }


    }
}