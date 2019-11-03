using System.Collections.Generic;
using System.Threading.Tasks;
using InnerSpace.Application.Queries.EventLog;
using InnerSpace.Application.ReadModels;

namespace InnerSpace.IntegrationsTests.Factories
{
    public class EventLogFactory: BaseFactory
    {
        public EventLogFactory():base()
        {

        }
        public static async Task< List<EventLogReadModel>> GetList()
        {
            EventLogsListQuery eventlogListQuery = new EventLogsListQuery();
            List<EventLogReadModel> customerEventsLogs = await Mediator.Send(eventlogListQuery);
            return customerEventsLogs;
        }

    }
}
