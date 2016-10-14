using SharedKernel.Messaging;
using System;

namespace SharedKernel.Interfaces
{
    public interface IEventHandler<T> where T : IMessage
    {
        void Handle(T args);

    }
}
