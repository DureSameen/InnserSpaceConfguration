using System;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace InnerSpace.UnitTests
{
    public class CustomerSubscriptionsConfigurationsTests
    {
         
        [Test]
        public void CustomerSubscriptionsConfigurationsCreatedSuccessfully()
        {
            var _customerSubscriptionsConfigurationsRepository = StartUpTests.ServiceProvider.GetService<ICustomerSubscriptionsConfigurationsRepository>();

            Guid configurationId = Guid.NewGuid();
            Guid userSubscriptionId = Guid.NewGuid();
            CustomerSubscriptionsConfigurations customerSubscription = CustomerSubscriptionsConfigurations.Create(userSubscriptionId, configurationId,false);
            _customerSubscriptionsConfigurationsRepository.Save(customerSubscription);
            StartUpTests.UnitOfWork.Save();
            Assert.IsNotNull(customerSubscription.Id);

            CustomerSubscriptionsConfigurations customerSubscriptionsConfigurationsRead = _customerSubscriptionsConfigurationsRepository.Find(customerSubscription.Id);

            Assert.IsNotNull(customerSubscriptionsConfigurationsRead);
            Assert.AreEqual(configurationId, customerSubscriptionsConfigurationsRead.ConfigurationId);
            Assert.AreEqual(userSubscriptionId, customerSubscriptionsConfigurationsRead.UserSubscriptionId);
            Assert.AreEqual(false, customerSubscriptionsConfigurationsRead.Enabled);
        }

        
    }
}