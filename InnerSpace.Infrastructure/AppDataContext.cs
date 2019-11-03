using InnerSpace.Domain.Aggregates.ConfigurationAggregate;
using InnerSpace.Domain.Aggregates.CustomerSubscriptionsConfigurationsAggregate;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;


namespace InnerSpace.Infrastructure
{
    public class AppDataContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Configuration> Configurations { get; set; } 
        public DbSet<SubscriptionConfiguration> SubcriptionConfigurations { get; set; } 
        public DbSet<UserSubscriptions> UserSubcriptions { get; set; } 
        public DbSet<CustomerSubscriptionsConfigurations> CustomerSubscriptionsConfigurations { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
            //
        }
    }
}
