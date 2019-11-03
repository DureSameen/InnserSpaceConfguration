using System;

namespace InnerSpace.Infrastructure.Logging
{
    public class EventLog
    {
        public Guid Id { get; set; }
        public string Type { get; private set; }
        public string Data { get; private set; }
        public Guid EntityId { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }

        public EventLog()
        {
            //
        }

        public EventLog(string type, string data, Guid entityId)
        {
            Type = type;
            Data = data;
            EntityId = entityId;
            CreatedOn = DateTimeOffset.UtcNow;
        }
    }
}
