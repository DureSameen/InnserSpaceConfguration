using System;
using System.Threading.Tasks;
using InnerSpace.IntegrationsTests.Factories;
using NUnit.Framework;

namespace InnerSpace.IntegrationsTests
{

    public class SubcriptionConfigurationTests
    { 
        [Test]
        public async Task CreateSubcriptionConfigurationSuccessfully()
        {
            //create a subscription..standard

            string subscriptionName = "Standard";
            var subcriptionId = await SubcriptionFactory.Create(subscriptionName, true);
            Assert.AreNotEqual(subcriptionId, Guid.Empty);

            var subscription = await SubcriptionFactory.GetById(subcriptionId);
            Assert.AreEqual(subscriptionName, subscription.Name);

            //create a configuration.. transcript

            string configurationName = "Transcript";
            var configurationId = await ConfigurationFactory.Create(configurationName, true);

            Assert.AreNotEqual(configurationId, Guid.Empty);

            var configuration = await ConfigurationFactory.GetById(configurationId);
            Assert.AreEqual(configurationName, configuration.Name);

            //create a subcription configuration.. transcript in stanadard

            var subcriptionConfigurationId= await SubcriptionConfigurationFactory.Create(subcriptionId, configurationId, true);
            Assert.AreNotEqual(subcriptionConfigurationId, Guid.Empty);
        }


    }
}