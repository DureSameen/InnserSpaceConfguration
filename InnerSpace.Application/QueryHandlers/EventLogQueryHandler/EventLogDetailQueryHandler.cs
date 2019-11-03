using System.Threading;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.EventLog;
using InnerSpace.Application.ReadModels;
using InnerSpace.Infrastructure.Logging;
using InnerSpace.Infrastructure.Repositories.Abstraction;
using InnerSpace.Infrastructure.Repositories.Logging;
using MediatR;

namespace InnerSpace.Application.QueryHandlers.EventLogQueryHandler
{
    public class EventLogDetailQueryHandler : IRequestHandler<EventLogDetailQuery, EventLogReadModel>
    {
        private readonly IEventLogRepository _customerEventsLogRepository;

        public EventLogDetailQueryHandler(IEventLogRepository customerEventsLogRepository)
        {
            _customerEventsLogRepository = customerEventsLogRepository;
        }

        public Task<EventLogReadModel> Handle(EventLogDetailQuery request, CancellationToken cancellationToken)
        {
            EventLog customerEventsLog = _customerEventsLogRepository.Find(request.Id);
            EventLogReadModel customerEventsLogReadModel = null;

            if (customerEventsLog != null)
            {
                customerEventsLogReadModel = new EventLogReadModel
                {
                    Id = customerEventsLog.Id,
                    CreatedOn = customerEventsLog.CreatedOn,
                    Data= customerEventsLog.Data,
                    EntityId= customerEventsLog.EntityId,
                    Type= customerEventsLog.Type
                };
            }

            return Task.FromResult(customerEventsLogReadModel);
        }
    }
}
