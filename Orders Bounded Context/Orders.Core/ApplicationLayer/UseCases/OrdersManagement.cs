using Orders.Core.ApplicationLayer.Interfaces;
using Orders.Core.ApplicationLayer.Commands;
using System.Collections.Generic;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using Orders.Core.Domain.OrderAggregate;
using Orders.Core.Domain.Interfaces.Repository;

namespace Orders.Core.ApplicationLayer.UseCases
{
    public sealed class OrdersManagement : UseCase, IOrdersManagement
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBus _bus;
        public OrdersManagement(INotifiable<DomainNotification> domainNotification, IEnumerable<IUnitOfWork> uow,
            IOrderRepository orderRepository, IBus bus)
            : base(domainNotification, uow)
        {
            _orderRepository = orderRepository;
            _bus = bus;

        }

        public void PlaceAnOrder(PlaceAnOrderCommand command)
        {
            var itens = new List<OrderItem>();
            foreach (var item in command.Itens)
            {
                var newItem = new OrderItem(item.ProductId, item.Quantity);
                itens.Add(newItem);
            }
            var newOrder = new Order(itens, command.UserId);
            if (newOrder.IsValid())
            {
                _orderRepository.Create(newOrder);                
                _bus.RaiseEvent(new OrderPlaced(newOrder.Id,newOrder.UserId,newOrder.Itens.Count));
            }

            Commit();
        }

    }
}
