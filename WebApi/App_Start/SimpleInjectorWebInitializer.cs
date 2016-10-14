using IoC;
using Orders.Core.ApplicationLayer.Handlers;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using SharedKernel.NaveInMemoryBus;
using Shipping.Core.ApplicationLayer.Handlers;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using WebApi.Helpers;

namespace WebApi.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {

        public static void Initialize(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            BootsTrapper.Register(container);
            var dependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            container.RegisterSingleton<IBus>(() => new Bus(new DomainEventsContainer(dependencyResolver)));
            container.RegisterWebApiControllers(config);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
            DomainEvent.Container = new DomainEventsContainer(dependencyResolver);
            RegisterSubscribers(container.GetInstance<IBus>());


        }

        public static void RegisterSubscribers(IBus bus)
        {
            bus.RegisterHandler<OrderPlacedHandler>();
            bus.RegisterHandler<NewOrderForShippingCommandHandler>();
        }
    }
}