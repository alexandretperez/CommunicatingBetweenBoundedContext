using SharedKernel.Events;
using SharedKernel.Interfaces;
using Shipping.Core.ApplicationLayer.UseCases;
using Shipping.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Shipping.Core.ApplicationLayer.Handlers
{
    public class NewOrderForShippingCommandHandler : UseCase, IMessageHandler<OrderPlaced>
    {
        private readonly IShippingRepository _shippingRepository;

        public NewOrderForShippingCommandHandler
            (IShippingRepository shippingRepository,
            INotifiable<DomainNotification> notification,
            IEnumerable<IUnitOfWork> uow)
            : base(notification, uow)
        {
            _shippingRepository = shippingRepository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Handle(OrderPlaced args)
        {
            Debug.WriteLine("shipping context notificado");
            var newShipping =
                   new Domain.ShippingAggregate.Shipping(args.OrderId, args.UserId, args.ItemsQuantity);
            _shippingRepository.Create(newShipping);
            Commit();
        }
    }
}
