using System;
using SharedKernel.Messaging;

namespace SharedKernel.Events
{
    public sealed class OrderPlaced : IMessage
    {
        private DateTime _dateOccured;
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccured;
            }
        }

        public Guid OrderId { get; private set; }
        public Guid UserId { get; private set; }
        public int ItemsQuantity { get; private set; }

        public OrderPlaced(Guid orderId, Guid userId, int qtde)
        {
            _dateOccured = DateTime.Now;
            OrderId = orderId;
            UserId = userId;
            ItemsQuantity = qtde;

        }
    }
}
