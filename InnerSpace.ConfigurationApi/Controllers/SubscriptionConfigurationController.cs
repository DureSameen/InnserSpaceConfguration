using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.SubscriptionConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// All configurations for a subscription, are saved in this api for admin only.
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class SubscriptionConfigurationController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public SubscriptionConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<SubcriptionConfigurationReadModel>> Get([FromQuery] SubscriptionConfigurationsDetailQuery query)
        {
            SubcriptionConfigurationReadModel subscriptionConfiguration = await _mediator.Send(query);

            return subscriptionConfiguration;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<SubcriptionConfigurationReadModel>>> GetList([FromQuery] SubscriptionConfigurationsListQuery query)
        { 
            List<SubcriptionConfigurationReadModel> subscriptionConfigurations = await _mediator.Send(query);

            return subscriptionConfigurations;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateSubcriptionConfigurationCommand command)
        {
            Guid subscriptionConfigurationId = await _mediator.Send(command);

            return subscriptionConfigurationId;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Put(EditSubcriptionConfigurationCommand command)
        {
            
           var subscriptionConfigurationId = await _mediator.Send(command);

            return subscriptionConfigurationId;
        }
    }
}
