using System;
using System.Linq;
using System.Threading.Tasks;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.IntegrationsTests.Factories;
using NUnit.Framework;

namespace InnerSpace.IntegrationsTests
{
    public class CustomerSubscriptionsConfigurationsTests
    {
        [Test]
        public async Task CreatCustomerSubscriptionsConfigurationsuccessfully()
        {

            //create a subscription..standard2 

            string subscriptionName = "Standard2";
            var subcriptionId = await SubcriptionFactory.Create(subscriptionName, true);
            Assert.AreNotEqual(subcriptionId, Guid.Empty);

            var subscription = await SubcriptionFactory.GetById(subcriptionId);
            Assert.AreEqual(subscriptionName, subscription.Name);

            //create a user subscription..with ApiKey

            var userSubscriptionId = await UserSubscriptionFactory.Create(ApiKeyHelper.CreateApiKey(), subcriptionId, Guid.NewGuid());
            Assert.AreNotEqual(userSubscriptionId, Guid.Empty);

            //create a configuration

            string configurationName = "Downloadable1";
            var configurationId = await ConfigurationFactory.Create(configurationName, true);

            Assert.AreNotEqual(configurationId, Guid.Empty);

            var configuration = await ConfigurationFactory.GetById(configurationId);
            Assert.AreEqual(configurationName, configuration.Name);


            //create a customer subscription configuration.. 
            var id = await CustomerSubscriptionsConfigurationsFactory.Create(configurationId, userSubscriptionId, false);


            Assert.AreNotEqual(id, Guid.Empty);

            var detailcustomer = await CustomerSubscriptionsConfigurationsFactory.GetById(id);

            Assert.AreEqual(configurationId, detailcustomer.ConfigurationId);
            Assert.AreEqual(false, detailcustomer.Enabled);

            //check logging of event also
            var eventlogs= await  EventLogFactory.GetList();
            var logEntry = eventlogs.Where(log => log.EntityId == id).FirstOrDefault();

            Assert.IsNotNull(logEntry);

             }

        #region Testing domainEvents

        [Test]
        public void Create_CustomerSubscritionConfiguration_With_Domain_Events()
        {
            Guid userSubsCriptionId = Guid.NewGuid();
            Guid configurationId = Guid.NewGuid();
            bool enabled = true;

            CustomerSubscriptionsConfigurations customerSubscriptionsConfigurations = CustomerSubscriptionsConfigurations.Create(userSubsCriptionId, configurationId, enabled);

            Assert.AreEqual(customerSubscriptionsConfigurations.UncommittedChanges().Count, 1);
        }

        [Test]
        public void Edit_CustomerSubscritionConfiguration_With_Domain_Events()
        {
            Guid userSubsCriptionId = Guid.NewGuid();
            Guid configurationId = Guid.NewGuid();
            bool enabled = true;

            CustomerSubscriptionsConfigurations customerSubscriptionsConfigurations = CustomerSubscriptionsConfigurations.Create(userSubsCriptionId, configurationId, enabled);

            customerSubscriptionsConfigurations.Edit(userSubsCriptionId, configurationId, false);

            Assert.AreEqual(customerSubscriptionsConfigurations.UncommittedChanges().Count, 2);
        }

        #endregion
    }
}