using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Subscription;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.SubscriptionAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// Different editions of trainings, available as subscription , managed by Admin only
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<SubscriptionReadModel>> Get([FromQuery] SubscriptionDetailQuery query)
        { 
            SubscriptionReadModel subscription = await _mediator.Send(query);

            return subscription;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<SubscriptionReadModel>>> GetList([FromQuery]  SubscriptionsListQuery query)
        { 
            List<SubscriptionReadModel> subscriptions = await _mediator.Send(query);

            return subscriptions;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateSubscriptionCommand command)
        {
            Guid subscriptionId = await _mediator.Send(command);

            return subscriptionId;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Put(EditSubscriptionCommand command)
        {
            
           var subscriptionId = await _mediator.Send(command);

            return subscriptionId;
        }
    }
}
