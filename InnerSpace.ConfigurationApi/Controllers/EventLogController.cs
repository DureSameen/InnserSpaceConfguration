using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.EventLog;
using InnerSpace.Application.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerSpace.Api.Controllers
{/// <summary>
/// Eventlogs api for auditor only
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AuditorOnly")]
    public class EventLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public EventLogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// a log by id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<EventLogReadModel>> Get([FromQuery] EventLogDetailQuery query)
        {
            EventLogReadModel customerEventsLog = await _mediator.Send(query);

            return customerEventsLog;
        }
        /// <summary>
        /// Log list 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<EventLogReadModel>>> GetList([FromQuery] EventLogsListQuery query)
        { 
            List<EventLogReadModel> customerEventsLogs = await _mediator.Send(query);

            return customerEventsLogs;
        } 
        
    }
}
