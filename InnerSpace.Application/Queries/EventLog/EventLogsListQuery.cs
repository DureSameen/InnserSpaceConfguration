using System.Collections.Generic;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.EventLog
{
    public class EventLogsListQuery : IRequest<List<EventLogReadModel>>
    {
        //
    }
}
