using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InnerSpace.IntegrationsTests.Factories
{
    public abstract class BaseFactory
    {
        public static IMediator Mediator => StartUpTests.ServiceProvider.GetService<IMediator>();
        

    }
}
