using System;
using SharedKernel.Interfaces;
using System.Collections.Generic;
using SharedKernel.Messaging;
using System.Linq;

namespace SharedKernel.NaveInMemoryBus
{
    public class Bus : IBus
    {


        private readonly IList<Type> _handlers;

        private readonly IContainer _container;

        public Bus(IContainer container)
        {
            _container = container;
            _handlers = new List<Type>();
        }

        public void RaiseEvent<T>(T theEvent) where T : IMessage
        {
            Send<T>(theEvent);
        }

        public void RegisterHandler<T>()
        {
            _handlers.Add(typeof(T));
        }

        public void SendCommand<T>(T theCommand) where T : IMessage
        {
            Send<T>(theCommand);
        }

        private void Send<T>(T message) where T : IMessage
        {
            var constructedType = typeof(IMessageHandler<>).MakeGenericType(typeof(T));
            var handlersToNotify = _handlers.Where(h => constructedType.IsAssignableFrom(h));

            foreach (var handler in handlersToNotify)
            {
                var instance = _container.GetService(handler);
                var method = constructedType.GetMethod("Handle", new[] { typeof(T) });
                method.Invoke(instance, new object[] { message });
            }

        }
    }
}
