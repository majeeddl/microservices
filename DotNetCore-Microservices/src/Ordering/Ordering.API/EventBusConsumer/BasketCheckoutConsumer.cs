using EventBus.Messages.Events;
using MassTransit;

namespace Ordering.API.EventBusConsumer;

public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
{
    public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        throw new NotImplementedException();
    }
}