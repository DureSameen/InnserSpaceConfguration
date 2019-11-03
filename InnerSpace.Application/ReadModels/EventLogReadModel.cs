
using System;

namespace InnerSpace.Application.ReadModels
{
   public class EventLogReadModel: BaseReadModel
    { 
        public string Type { get; set; }
        public string Data { get; set; }
        public Guid EntityId { get;  set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
