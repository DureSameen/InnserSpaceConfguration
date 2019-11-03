
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using InnerSpace.Startup;
using InnerSpace.Infrastructure;

namespace InnerSpace.UnitTests
{
    [SetUpFixture]
    public static class StartUpTests
    {
        public static System.IServiceProvider ServiceProvider { get; set; }
        public static IUnitOfWork UnitOfWork => StartUpTests.ServiceProvider.GetService<IUnitOfWork>();

        [OneTimeSetUp]
        public static void SetUpTests()
        { 
            

            IServiceCollection services = new  ServiceCollection();
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
