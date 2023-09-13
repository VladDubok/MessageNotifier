using Common.RabbitMq.Messages;
using MassTransit;

namespace Common.RabbitMq.Consumers;
public class SendEmailMessageConsumer : IConsumer<SendEmailMessage>
{
    public Task Consume(ConsumeContext<SendEmailMessage> context)
    {
        throw new NotImplementedException();
    }
}
