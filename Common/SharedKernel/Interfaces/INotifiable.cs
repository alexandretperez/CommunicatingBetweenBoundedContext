using SharedKernel.Messaging;
using System;
using System.Collections.Generic;

namespace SharedKernel.Interfaces
{
    public interface INotifiable<T> : IDisposable where T : IMessage
    {
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
