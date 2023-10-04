namespace Common.RabbitMq.Messages;
public class SendEmailMessage
{
    public string Event { get; set;} = null!;
    public string? Data { get; set; }
}
