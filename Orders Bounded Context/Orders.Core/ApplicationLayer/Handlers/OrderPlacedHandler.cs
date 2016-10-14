using SharedKernel.Events;
using SharedKernel.Interfaces;
using System;
using System.Diagnostics;

namespace Orders.Core.ApplicationLayer.Handlers
{
    public class OrderPlacedHandler : IMessageHandler<OrderPlaced>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Handle(OrderPlaced args)
        {
            Debug.WriteLine($"pedido criado - id:{args.OrderId} - quantidade: {args.ItemsQuantity} ");

        }
    }
}
