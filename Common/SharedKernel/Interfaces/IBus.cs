using SharedKernel.Messaging;

namespace SharedKernel.Interfaces
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : IMessage;
        void RaiseEvent<T>(T theEvent) where T : IMessage;
        void RegisterHandler<T>();
    }
}
