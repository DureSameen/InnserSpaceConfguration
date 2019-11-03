using System;
using InnerSpace.Domain.Aggregates.UserSubscriptionsAggregate;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace InnerSpace.UnitTests
{
    public class UserSubscriptionsTests
    {
         
        [Test]
        public void UserSubscriptionsCreatedSuccessfully()
        {
            var _userSubscriptionsRepository = StartUpTests.ServiceProvider.GetService<IUserSubscriptionsRepository>();

            Guid userId = Guid.NewGuid();
            Guid subscriptionId = Guid.NewGuid();
            UserSubscriptions userSubscription = UserSubscriptions.Create(subscriptionId,userId, "KKKL");
            _userSubscriptionsRepository.Save(userSubscription);
            StartUpTests.UnitOfWork.Save();
            Assert.IsNotNull(userSubscription.Id);

            UserSubscriptions userSubscriptionRead = _userSubscriptionsRepository.Find(userSubscription.Id);

            Assert.IsNotNull(userSubscriptionRead);
            Assert.AreEqual(userId, userSubscriptionRead.UserId);
            Assert.AreEqual(subscriptionId, userSubscriptionRead.SubcriptionId);
             
        }

        
    }
}