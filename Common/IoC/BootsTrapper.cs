using Orders.Core.ApplicationLayer.Handlers;
using Orders.Core.ApplicationLayer.Interfaces;
using Orders.Core.ApplicationLayer.UseCases;
using Orders.Core.Domain.Interfaces.Repository;
using Orders.Infra.config;
using Orders.Infra.Context;
using Orders.Infra.Repository.EF;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using Shipping.Core.ApplicationLayer.Handlers;
using Shipping.Core.ApplicationLayer.Interfaces;
using Shipping.Core.ApplicationLayer.Queries;
using Shipping.Core.Domain.Interfaces.Repository;
using Shipping.Infra.config;
using Shipping.Infra.Context;
using Shipping.Infra.Repository.EF;
using Shipping.Infra.Repository.EntLib;
using SimpleInjector;

namespace IoC
{
    public sealed class BootsTrapper
    {
        public static void Register(Container container)
        {
            container.RegisterPerWebRequest<IOrdersManagement, OrdersManagement>();
            container.RegisterPerWebRequest<IShippingQuery, ShippingQuery>();

            var domainHandler = Lifestyle.Singleton.CreateRegistration<DomainNotificationHandler>(container);
            var orderPlacedHandler = Lifestyle.Singleton.CreateRegistration<OrderPlacedHandler>(container);

            container.RegisterSingleton<ShippingContext>();
            container.RegisterSingleton<OrderContext>();
            container.RegisterSingleton<IShippingRepository, ShippingRepository>();
            container.RegisterSingleton<IShippingADORepository, ShippingADORepository>();
            container.RegisterSingleton<IOrderRepository, OrderRepository>();



            container.AddRegistration(typeof(INotifiable<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(IMessageHandler<DomainNotification>), domainHandler);
            container.RegisterCollection<IMessageHandler<OrderPlaced>>(new[] { typeof(OrderPlacedHandler).Assembly, typeof(NewOrderForShippingCommandHandler).Assembly });
            container.RegisterCollection<IUnitOfWork>(new[] { typeof(ShippingUnitOfWork).Assembly, typeof(OrderUnitOfWork).Assembly });


        }
    }
}
