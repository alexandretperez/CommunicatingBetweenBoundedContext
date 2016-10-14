using SharedKernel.Messaging;
using System;

namespace Orders.Core.ApplicationLayer.Commands
{
    public sealed class CreateOrderItemCommand : IMessage
    {

        public CreateOrderItemCommand(int quantity, string productId)
        {
            Quantity = quantity;
            ProductId = Guid.Parse(productId);
        }
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }
    }
}
