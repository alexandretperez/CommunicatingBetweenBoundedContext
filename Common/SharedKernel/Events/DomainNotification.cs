using SharedKernel.Messaging;
using System;

namespace SharedKernel.Events
{
    public sealed class DomainNotification : IMessage
    {

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            DateOccurred = DateTime.Now;
        }
        public DateTime DateOccurred { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
