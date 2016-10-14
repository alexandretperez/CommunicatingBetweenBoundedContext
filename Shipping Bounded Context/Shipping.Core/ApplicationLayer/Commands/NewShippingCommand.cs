using System;
using SharedKernel.Messaging;

namespace Shipping.Core.ApplicationLayer.Commands
{
    public class NewShippingCommand : IMessage
    {
        public int ItemsQuantity { get; internal set; }
        public Guid OrderId { get; internal set; }
        public Guid UserId { get; internal set; }

        internal bool IsValid()
        {
            return true;
        }
    }
}
