using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
 

namespace InnerSpace.UnitTests
{
    public class ConfigurationTests
    {   
        [Test]
        public void ConfigurationCreatedSuccessfully()
        {
            var _configurationRepository = StartUpTests.ServiceProvider.GetService<IConfigurationRepository>();
            
            string configurationName = "AName";
            Configuration configuration = Configuration.Create(configurationName, true);
            _configurationRepository.Save(configuration);
            StartUpTests.UnitOfWork.Save();
            Assert.IsNotNull(configuration.Id);

            Configuration configurationRead = _configurationRepository.Find(configuration.Id);

            Assert.IsNotNull(configurationRead);
            Assert.AreEqual(configurationName, configurationRead.Name);
            Assert.AreEqual(true, configurationRead.Enabled);
        }

        
    }
}