using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.Queries.CustomerSubscriptionsConfigurations;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// Customer customerSubscriptionConfiguration configurations managed by customers only.
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CustomerOnly")]
    public class CustomerSubscriptionsConfigurationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerSubscriptionsConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Retrieve a customer customerSubscriptionConfiguration configuration by id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<CustomerSubscriptionsConfigurationsReadModel>> Get([FromQuery] CustomerSubscriptionsConfigurationsDetailQuery query)
        {
            CustomerSubscriptionsConfigurationsReadModel customerSubscriptionConfiguration = await _mediator.Send(query);

            return customerSubscriptionConfiguration;
        }
        /// <summary>
        /// List of customer customerSubscriptionConfiguration configurations
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<CustomerSubscriptionsConfigurationsReadModel>>> GetList([FromQuery] CustomerSubscriptionsConfigurationsListQuery query)
        { 
            List<CustomerSubscriptionsConfigurationsReadModel> customerSubscriptionConfigurations = await _mediator.Send(query);

            return customerSubscriptionConfigurations;
        }
        /// <summary>
        /// Add a new customer customerSubscriptionConfiguration configuration record.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateCustomerSubscriptionsConfigurationsCommand command)
        {
            Guid customerSubscriptionConfigurationId = await _mediator.Send(command);

            return customerSubscriptionConfigurationId;
        }
        /// <summary>
        /// Edit a custom customerSubscriptionConfiguration configuration record.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Guid>> Put(EditCustomerSubscriptionsConfigurationsCommand command)
        {
            
           var customerSubscriptionConfigurationId = await _mediator.Send(command);

            return customerSubscriptionConfigurationId;
        }
    }
}
