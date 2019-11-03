using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.Queries.UserSubscriptions;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// User's Subscription of different available Subscriptions alongwith API key , managed by customers and field engineers.
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CustomerOnly")]
    [Authorize(Policy = "FieldEngineerOnly")]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UserSubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<UserSubcriptionReadModel>> Get([FromQuery] UserSubscriptionDetailQuery query)
        {
            UserSubcriptionReadModel userSubscription = await _mediator.Send(query);

            return userSubscription;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<UserSubcriptionReadModel>>> GetList([FromQuery]  UserSubscriptionsListQuery query)
        { 
            List<UserSubcriptionReadModel> userSubscriptions = await _mediator.Send(query);

            return userSubscriptions;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateUserSubscriptionCommand command)
        {
            Guid userSubscriptionId = await _mediator.Send(command);

            return userSubscriptionId;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Put(EditUserSubscriptionCommand command)
        {
            
           var userSubscriptionId = await _mediator.Send(command);

            return userSubscriptionId;
        }
    }
}
