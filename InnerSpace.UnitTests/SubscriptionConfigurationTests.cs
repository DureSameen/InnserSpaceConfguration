using System;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using InnerSpace.Infrastructure.Repositories.Abstraction;

namespace InnerSpace.UnitTests
{
    public class SubscriptionConfigurationTests
    {  
        [Test]
        public void SubscriptionConfigurationCreatedSuccessfully()
        {
            var _subscriptionConfigurationRepository = StartUpTests.ServiceProvider.GetService<ISubscriptionConfigurationRepository>();

            Guid configurationId = Guid.NewGuid();
            Guid subscriptionId = Guid.NewGuid();
            SubscriptionConfiguration subsconfiguration = SubscriptionConfiguration.Create(subscriptionId,configurationId,  true);
            _subscriptionConfigurationRepository.Save(subsconfiguration);

            StartUpTests.UnitOfWork.Save();
            Assert.IsNotNull(subsconfiguration.Id);

            SubscriptionConfiguration subscriptionConfigurationRead = _subscriptionConfigurationRepository.Find(subsconfiguration.Id);

            Assert.IsNotNull(subscriptionConfigurationRead);
            Assert.AreEqual(subscriptionId, subscriptionConfigurationRead.SubcriptionId);
            Assert.AreEqual(configurationId, subscriptionConfigurationRead.ConfigurationId);
            Assert.AreEqual(true, subscriptionConfigurationRead.Enabled);
        }

        
    }
}