using InnerSpace.Application.CommandHandlers.CustomerCommandHandler;
using InnerSpace.Infrastructure;
using InnerSpace.Infrastructure.Repositories;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using InnerSpace.Infrastructure.Repositories.Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InnerSpace.Startup
{
    public enum ProjectType
    {
        UnitTest,
        API

    }

    public class StartupIOC
    {
        public StartupIOC(IConfiguration configuration = null, ProjectType project = ProjectType.UnitTest)
        {
            Configuration = configuration;
            Project = project;
        }

        public IConfiguration Configuration { get; }
        public ProjectType Project { get; }

        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
           
            if (Project == ProjectType.API)
                services.AddDbContext<AppDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));
            else
                services.AddDbContext<AppDataContext>(options => options.UseInMemoryDatabase("InnerSpace"));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISubscriptionRepository, SubscriptionsRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationsRepository>();
            services.AddScoped<ISubscriptionConfigurationRepository, SubcriptionConfigurationsRepository>();
            services.AddScoped<IUserSubscriptionsRepository, UserSubscriptionsRepository>();
            services.AddScoped<ICustomerSubscriptionsConfigurationsRepository, CustomerSubscriptionsConfigurationsRepository>();
            services.AddScoped<IEventLogRepository, EventLogRepository>();
            services.AddMediatR(typeof(CreateSubscriptionCommandHandler).Assembly);

            return services;
        }
        public void Configure()
        {
        }
    }
}