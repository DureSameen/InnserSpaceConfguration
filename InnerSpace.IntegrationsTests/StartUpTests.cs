
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using InnerSpace.Startup;

namespace InnerSpace.IntegrationsTests
{
    [SetUpFixture]
    public static class StartUpTests
    {
        public static System.IServiceProvider ServiceProvider { get; set; }

        [OneTimeSetUp]
        public static void SetUpTests()
        {


            IServiceCollection services = new ServiceCollection();
            StartupIOC target = new StartupIOC();
            target.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

        }
        [OneTimeTearDown]
        public static void TearDownTests()
        {

        }

    }
}
