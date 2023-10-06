using Common.RabbitMq.Messages;
using MassTransit;
using MessageService.Data;
using Microsoft.EntityFrameworkCore;

namespace MessageService.HostedServices;

public class DomainEventHostedService : BackgroundService
{
    private readonly MessageApplicationContext _context;
    private readonly IBus _bus;

    public DomainEventHostedService(
        MessageApplicationContext context,
        IBus bus)
    {
        _context = context;
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var events = await _context.MessageEvents.ToArrayAsync(cancellationToken);

            if ( !events.Any())
            {
                await Task.Delay(1000);
                continue;
            }

            var sendEmailMessages = events.Select(x => new SendEmailMessage { Event = x.Event, Data = x.Data }).ToArray();

            foreach (var sendEmailMessage in sendEmailMessages)
            {
                await _bus.Publish(sendEmailMessage, cancellationToken);
            }
        }
    }
}