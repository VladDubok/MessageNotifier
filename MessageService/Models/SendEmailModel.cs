namespace MessageService.Models
{
    public class SendEmailModel
    {
        public string From { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string To { get; set; } = null!;
    }
}