using Common.RabbitMq.Messages;
using MassTransit;

namespace EmailService.Consumers;
public class SendEmailMessageConsumer : IConsumer<SendEmailMessage>
{
    public Task Consume(ConsumeContext<SendEmailMessage> context)
    {
        switch (context.Message.Event)
        {
            case "AddEmailMessage":
            {
                Console.WriteLine("SendEmail");
                break;
            }
                
        }

        return Task.CompletedTask;
    }
}
