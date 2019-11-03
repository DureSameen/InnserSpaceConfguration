using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.Configuration;
using InnerSpace.Application.ReadModels;
using InnerSpace.Domain.Aggregates.ConfigurationAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// Basic configruation management api for admin only
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    
    public class ConfigurationController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// retrieve configuration by Id 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<ConfigurationReadModel>> Get([FromQuery] ConfigurationDetailQuery query)
        {
            ConfigurationReadModel configuration = await _mediator.Send(query);

            return configuration;
        }
        /// <summary>
        /// List of configuration 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<ConfigurationReadModel>>> GetList([FromQuery] ConfigurationsListQuery query)
        { 
            List<ConfigurationReadModel> configurations = await _mediator.Send(query);

            return configurations;
        }
        /// <summary>
        /// Add a new configuration
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateConfigurationCommand command)
        {
            Guid configurationId = await _mediator.Send(command);

            return configurationId;
        }
        /// <summary>
        /// Edit a configuration
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Guid>> Put(EditConfigurationCommand command)
        {

            Guid configurationId = await _mediator.Send(command);

            return configurationId;
        }
    }
}
