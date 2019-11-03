using System;
using InnerSpace.Application.ReadModels;
using MediatR;

namespace InnerSpace.Application.Queries.EventLog
{
    public class EventLogDetailQuery : IRequest<EventLogReadModel>
    {
        public Guid Id { get; set; }
    }
}
