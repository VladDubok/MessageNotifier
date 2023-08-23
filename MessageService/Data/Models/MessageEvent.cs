namespace MessageService.Data.Models;
public class MessageEvent
{
    public int Id { get; set;}
    public string Event { get; set;} = null!;
    public string? Data { get; set; }
}
