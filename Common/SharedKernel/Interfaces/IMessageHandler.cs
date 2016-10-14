using SharedKernel.Messaging;
using System;

namespace SharedKernel.Interfaces
{
    public interface IMessageHandler<T>  where T : IMessage
    {
        void Handle(T args);
    }
}
