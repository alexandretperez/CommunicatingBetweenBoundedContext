using SharedKernel.Interfaces;
using SharedKernel.Messaging;
using System;

namespace SharedKernel.Events
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IMessage
        {
            try
            {
                if (Container != null)

                {
                    var obj = Container.GetService(typeof(IMessageHandler<T>));
                    ((IMessageHandler<T>)obj).Handle(args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in container events", ex);
            }
        }
    }
}
