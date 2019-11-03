using System;
using System.Threading.Tasks;
using InnerSpace.IntegrationsTests.Factories;
using NUnit.Framework;

namespace InnerSpace.IntegrationsTests
{

    public class ConfigurationTests
    { 
        [Test]
        public async Task CreateConfigurationSuccessfully()
        {
            string configurationName = "Downloadable";
            var configurationId= await ConfigurationFactory.Create(configurationName, true);
            
            Assert.AreNotEqual(configurationId, Guid.Empty);

            var configuration=await ConfigurationFactory.GetById(configurationId);
            Assert.AreEqual(configurationName, configuration.Name);
        }

        
    }
}