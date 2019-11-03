using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.EventLog;
using InnerSpace.Application.ReadModels;
using InnerSpace.Infrastructure.Logging;
using InnerSpace.Infrastructure.Repositories.Logging;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.EventLogQueryHandler
{
    public class EventLogsListQueryHandler : IRequestHandler<EventLogsListQuery, List<EventLogReadModel>>
    {
        private readonly IEventLogRepository _customerEventsLogRepository;

        public EventLogsListQueryHandler(IEventLogRepository customerEventsLogRepository)
        {
            _customerEventsLogRepository = customerEventsLogRepository;
        }

        public Task<List<EventLogReadModel>> Handle(EventLogsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<EventLog> customerEventsLogs = _customerEventsLogRepository.Query();
            List<EventLogReadModel> customerEventsLogsListReadModel = null;

            if (customerEventsLogs != null && customerEventsLogs.Any())
            {
                customerEventsLogsListReadModel = customerEventsLogs.Select(x => new EventLogReadModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Data = x.Data,
                    EntityId = x.EntityId,
                    Type = x.Type
                }).ToList();
            }

            return Task.FromResult(customerEventsLogsListReadModel);
        }
    }
}
